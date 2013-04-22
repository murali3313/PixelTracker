using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace RecordAndPlayBack
{
internal class ConstraintViolationException : Exception { }
        internal class IncorrectFormatException : Exception { }


     
        public class Repository 
        {

            static Repository repository;
            private static readonly Dictionary<Type, SqlDbType> ClrSqlTypeMappings = new Dictionary<Type, SqlDbType>();

            private readonly string connectionString;

            public string ConnectionString
            {
                get
                {
                    return connectionString;
                }
            }

            static Repository()
            {
                ClrSqlTypeMappings.Add(typeof(bool), SqlDbType.Bit);
                ClrSqlTypeMappings.Add(typeof(DateTime), SqlDbType.DateTime);
                ClrSqlTypeMappings.Add(typeof(double), SqlDbType.Decimal);
                ClrSqlTypeMappings.Add(typeof(int), SqlDbType.Int);
            }

            public static Repository Instance
            {
                get
                {
                    if (repository != null)
                        return repository;
                    repository = new Repository();
                    return repository;
                }
            }

            private Repository()
            {
                connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            }

            public IEnumerable<string> GetColumnNames(string tableName)
            {
                var columnNames = new List<string>();
                var getColumnHeadersQuery =
                    string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.Columns where TABLE_NAME = '{0}'", tableName);
                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var dbCommand = new SqlCommand(getColumnHeadersQuery, dbConnection))
                    {
                        dbConnection.Open();
                        var reader = dbCommand.ExecuteReader();
                        while (reader.Read())
                            columnNames.Add(reader.GetString(0));
                    }
                }
                return columnNames;
            }

            public DataTable LoadDataTableWithQuery(string selectQuery)
            {
                return LoadFromDataAdapter(selectQuery, false);
            }

            private DataTable LoadFromDataAdapter(string selectQuery, bool schemaOnly)
            {
                var unicodeQuery = SQLStatementFormatter.GetUnicodeStatement(selectQuery);
                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var adapter = new SqlDataAdapter(unicodeQuery, dbConnection))
                    {
                        var dataTable = new DataTable();
                        dbConnection.Open();
                        if (schemaOnly)
                        {
                            adapter.FillSchema(dataTable, SchemaType.Source);
                        }
                        else
                        {
                            adapter.Fill(dataTable);
                        }
                        return dataTable;
                    }
                }
            }

            
            public DataTable LoadDataTableSchema(string selectQuery)
            {
                return LoadFromDataAdapter(selectQuery, true);
            }

            
            public void Connect()
            {
                using (var dbConnection = new SqlConnection(connectionString))
                {
                    dbConnection.Open();
                }
            }


            
            public void ExecuteQuery(params string[] queries)
            {
                using (var dbConnection = new SqlConnection(connectionString))
                {
                    dbConnection.Open();
                    var transaction = dbConnection.BeginTransaction();
                    using (var dbCommand = new SqlCommand())
                    {
                        dbCommand.Transaction = transaction;
                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandTimeout = 300;

                        foreach (var query in queries)
                        {
                            var unicodeQuery = SQLStatementFormatter.GetUnicodeStatement(query);
                            dbCommand.CommandText = unicodeQuery;
                            try
                            {
                                dbCommand.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine(unicodeQuery);
                                Console.WriteLine(ex.Message);
                                transaction.Rollback();
                                throw;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(unicodeQuery);
                                Console.WriteLine(ex.Message);
                                transaction.Rollback();
                                throw;
                            }
                        }
                        transaction.Commit();
                    }
                }
            }

            
            public object ExecuteReader(string query)
            {
                var unicodeQuery = SQLStatementFormatter.GetUnicodeStatement(query);

                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    using (var dbCommand = new SqlCommand(unicodeQuery, sqlConnection))
                    {
                        sqlConnection.Open();
                        dbCommand.CommandTimeout = 300;
                        var reader = dbCommand.ExecuteReader();
                        if (reader.Read())
                            if (!reader.IsDBNull(0))
                                return reader.GetValue(0);
                        return null;
                    }
                }
            }

            
            public void ExecuteNonQuery(params string[] queries)
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand { Connection = sqlConnection };
                    sqlConnection.Open();
                    queries.ForEach(query =>
                    {
                        var unicodeQuery = SQLStatementFormatter.GetUnicodeStatement(query);
                        command.CommandText = unicodeQuery;
                        command.ExecuteNonQuery();
                    });
                }
            }

            
            public object ExecuteScalar(string query)
            {
                var unicodeQuery = SQLStatementFormatter.GetUnicodeStatement(query);

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var dbCommand = new SqlCommand(unicodeQuery, dbConnection))
                    {
                        dbCommand.CommandTimeout = 300;
                        dbConnection.Open();
                        return dbCommand.ExecuteScalar();
                    }
                }
            }

            public void RefreshPools()
            {
                SqlConnection.ClearAllPools();
            }

            
            public T ExecuteScalar<T>(string query)
            {
                var unicodeQuery = SQLStatementFormatter.GetUnicodeStatement(query);

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var dbCommand = new SqlCommand(unicodeQuery, dbConnection))
                    {
                        dbCommand.CommandTimeout = 300;
                        dbConnection.Open();
                        var resultObj = dbCommand.ExecuteScalar();
                        if (resultObj == DBNull.Value)
                        {
                            return default(T);
                        }

                        return (T)Convert.ChangeType(resultObj, typeof(T));
                    }
                }
            }

            
            public int ExecuteStoredProcedure(string procedureName, params SqlParameter[] arguments)
            {

                if (null != arguments)
                    foreach (var argument in arguments)
                    {
                        ConvertStringParamsToUnicode(argument);
                    }

                int rowsAffected;
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var dbCommand = new SqlCommand(procedureName, connection) { CommandTimeout = 300 })
                    {
                        connection.Open();
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        if (null != arguments)
                            dbCommand.Parameters.AddRange(arguments);
                        rowsAffected = dbCommand.ExecuteNonQuery();
                    }
                }
                return rowsAffected;
            }

            
            public object ExecuteScalarFromStoredProcedure(string procedureName, params SqlParameter[] arguments)
            {
                if (null != arguments)
                    foreach (var argument in arguments)
                    {
                        ConvertStringParamsToUnicode(argument);
                    }

                object result;
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var dbCommand = new SqlCommand(procedureName, connection) { CommandTimeout = 300 })
                    {
                        connection.Open();
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        if (null != arguments)
                            dbCommand.Parameters.AddRange(arguments);
                        result = dbCommand.ExecuteScalar();
                    }
                }
                return result;
            }

            private static void ConvertStringParamsToUnicode(SqlParameter param)
            {
                if (param.SqlDbType == SqlDbType.NVarChar && param.Value != null && param.Value != DBNull.Value)
                {
                    param.Value = SQLStatementFormatter.GetUnicodeStatement(param.Value.ToString());
                }
            }

            
            public DataTable LoadDataTableFromStoredProcedure(string procedureName, params SqlParameter[] arguments)
            {

                if (null != arguments)
                    foreach (var argument in arguments)
                    {
                        ConvertStringParamsToUnicode(argument);
                    }

                var dataTable = new DataTable();
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var dbCommand = new SqlCommand(procedureName, connection))
                    {
                        dbCommand.CommandTimeout = 300;
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        if (null != arguments)
                            dbCommand.Parameters.AddRange(arguments);

                        using (var adapter = new SqlDataAdapter(dbCommand))
                        {
                            connection.Open();
                            adapter.Fill(dataTable);
                        }
                    }
                }
                return dataTable;
            }

            public DataSet LoadDataSetFromStoredProcedure(string procedureName, params SqlParameter[] arguments)
            {

                if (null != arguments)
                    foreach (var argument in arguments)
                    {
                        ConvertStringParamsToUnicode(argument);
                    }

                var dataset = new DataSet();
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var dbCommand = new SqlCommand(procedureName, connection))
                    {
                        dbCommand.CommandTimeout = 300;
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        if (null != arguments)
                            dbCommand.Parameters.AddRange(arguments);

                        using (var adapter = new SqlDataAdapter(dbCommand))
                        {
                            connection.Open();
                            adapter.Fill(dataset);
                        }
                    }
                }
                return dataset;
            }

            public int ExecuteStoredProcedureWithTransaction(string procedureName, params SqlParameter[] arguments)
            {
                if (null != arguments)
                    foreach (var argument in arguments)
                    {
                        ConvertStringParamsToUnicode(argument);
                    }

                int rowsAffected;

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var dbCommand = new SqlCommand(procedureName, connection))
                    {
                        connection.Open();
                        var transaction = connection.BeginTransaction();
                        dbCommand.Transaction = transaction;
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandTimeout = 300;
                        if (null != arguments)
                            dbCommand.Parameters.AddRange(arguments);
                        try
                        {
                            rowsAffected = dbCommand.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        transaction.Commit();
                    }
                }
                return rowsAffected;
            }



            
            public int ExecuteStoredProcedure(string procedureName)
            {
                return ExecuteStoredProcedure(procedureName, null);
            }

            
            public void ExecuteStoredProcedures(params string[] procedureNames)
            {
                if (procedureNames == null || procedureNames.Length == 0)
                {
                    return;
                }

                using (var transactionScope = new TransactionScope())
                {
                    using (var sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();

                        foreach (var procedureName in procedureNames)
                        {

                            using (var sqlCmd = new SqlCommand(procedureName, sqlConnection) { CommandTimeout = 300 })
                            {
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    transactionScope.Complete();
                }
            }

            
            public int BulkCopy(DataTable sourceDataTable, string destinationTable, ColumnMappingCollection columnMappings)
            {
                using (var dbConnection = new SqlConnection(connectionString))
                {
                    dbConnection.Open();
                    var bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.UseInternalTransaction)
                    {
                        DestinationTableName = destinationTable,
                        BulkCopyTimeout = 300,
                        BatchSize = sourceDataTable.Rows.Count,
                    };

                    if (columnMappings != null)
                        columnMappings.ForEach(mapping =>
                        {
                            if (sourceDataTable.Columns.Contains(mapping.SourceColumn))
                                bulkCopy.ColumnMappings.Add(mapping.SourceColumn, mapping.DestinationColumn);
                        });

                    bulkCopy.WriteToServer(sourceDataTable);
                }
                return sourceDataTable.Rows.Count;
            }

            
            public void BulkCopyToMultipleTablesWithIdentityInsertOn(List<DataTable> dataTables)
            {
                using (var dbConnection = new SqlConnection(connectionString))
                {
                    dbConnection.Open();
                    var transaction = dbConnection.BeginTransaction();

                    using (var bulkCopy = new SqlBulkCopy(dbConnection, SqlBulkCopyOptions.KeepIdentity, transaction))
                    {
                        bulkCopy.BulkCopyTimeout = 300;

                        foreach (var dataTable in dataTables)
                        {
                            bulkCopy.BatchSize = dataTable.Rows.Count;
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                            }

                            bulkCopy.DestinationTableName = dataTable.TableName;
                            bulkCopy.WriteToServer(dataTable);
                            bulkCopy.ColumnMappings.Clear();
                        }
                    }
                    transaction.Commit();
                }
            }


            public void RefreshView(string viewName)
            {
                var vwName = new SqlParameter("@ViewName", viewName);
                ExecuteStoredProcedure("sp_refresh_views", vwName);
            }

            public void RefreshAllViews()
            {
                var isRefreshAllViews = new SqlParameter("@IsRefreshAllViews", true);
                ExecuteStoredProcedure("sp_refresh_views", isRefreshAllViews);
            }


            public object ExecuteReaderForStoredProcedure(string procedureName, params SqlParameter[] arguments)
            {
                if (null != arguments)
                    foreach (var argument in arguments)
                    {
                        ConvertStringParamsToUnicode(argument);
                    }

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var dbCommand = new SqlCommand(procedureName, connection))
                    {
                        dbCommand.CommandTimeout = 300;
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        if (null != arguments)
                            dbCommand.Parameters.AddRange(arguments);
                        var reader = dbCommand.ExecuteReader();
                        if (reader.Read())
                            if (!reader.IsDBNull(0))
                                return reader.GetValue(0);
                        return null;
                    }
                }
            }

            public DataTable GetSchema(SqlConnection sqlConnection, string query)
            {
                var unicodeQuery = SQLStatementFormatter.GetUnicodeStatement(query);

                var dataTable = new DataTable();
                using (var adapter = new SqlDataAdapter(unicodeQuery, sqlConnection))
                {
                    adapter.FillSchema(dataTable, SchemaType.Source);
                }
                return dataTable;
            }

            public void FetchData(SqlConnection sqlConnection, DataTable dataTable, string query)
            {
                var unicodeQuery = SQLStatementFormatter.GetUnicodeStatement(query);

                using (var adapter = new SqlDataAdapter(unicodeQuery, sqlConnection))
                {
                    adapter.Fill(dataTable);
                }
            }

            public void BulkCopy(SqlConnection sqlConnection, DataTable table, IEnumerable<string> fieldsToBeCopied)
            {
                using (var bulkCopy = new SqlBulkCopy(sqlConnection))
                {
                    fieldsToBeCopied.ForEach(selectedColumn => bulkCopy.ColumnMappings.Add(selectedColumn, selectedColumn));
                    bulkCopy.DestinationTableName = table.TableName;
                    bulkCopy.WriteToServer(table);
                }
            }
        }

    

}
