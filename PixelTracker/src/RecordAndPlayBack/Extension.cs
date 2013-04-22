using System;
using System.Collections.Generic;
using System.Data;

namespace RecordAndPlayBack
{
    public static class Extension
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }
        public static string GetDBField(this DataColumn column)
        {
            return column.ExtendedProperties.ContainsKey("DbField")
               ? column.ExtendedProperties["DbField"].ToString()
               : null;
        }
    }
}
