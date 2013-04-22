using System;
using System.Collections;
using System.Collections.Generic;

namespace RecordAndPlayBack
{

    public class ColumnMappingCollection : IEnumerable<ColumnMapping>
    {
        private readonly List<ColumnMapping> columnMappings = new List<ColumnMapping>();

        public void Add(string sourceColumn, string destinationColumn)
        {
            if (columnMappings.Exists(mapping => mapping.DestinationColumn == destinationColumn))
                throw new ApplicationException("Error");
            columnMappings.Add(new ColumnMapping { SourceColumn = sourceColumn, DestinationColumn = destinationColumn });
        }



        public int Count
        {
            get { return columnMappings.Count; }
        }

        public ColumnMapping this[int i]
        {
            get { return columnMappings[i]; }
        }

        public IEnumerator<ColumnMapping> GetEnumerator()
        {
            foreach (ColumnMapping cm in columnMappings)
                yield return cm;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            var otherCollection = (ColumnMappingCollection)obj;
            var equals = Count == otherCollection.Count;

            if (equals)
            {
                foreach (ColumnMapping cm in otherCollection.columnMappings)
                {
                    equals = columnMappings.Contains(cm);
                    if (!equals)
                        break;
                }
            }

            return equals;
        }

        public void Add(ColumnMappingCollection otherCollection)
        {
            if (otherCollection == null)
                return;
            foreach (ColumnMapping cm in otherCollection.columnMappings)
            {
                Add(cm.SourceColumn, cm.DestinationColumn);
            }
        }
    }

    public class ColumnMapping
    {
        public string SourceColumn { get; set; }

        public string DestinationColumn { get; set; }

        public override bool Equals(object obj)
        {
            var otherColumnMapping = (ColumnMapping)obj;
            return (otherColumnMapping.SourceColumn.Equals(SourceColumn) && otherColumnMapping.DestinationColumn.Equals(DestinationColumn));
        }
    }
}
