using System.Text;
using Microsoft.SqlServer.Management.SqlParser.Parser;

namespace RecordAndPlayBack
{
    public static class SQLStatementFormatter
    {

        public static string GetUnicodeStatement(string query)
        {
            //            return Regex.Replace(query, @"(?<m2>[ (,=])'(?<value>[\w\s~`!@#$%^&*()_+-={}[\]|\;:<>,.?/€£¥©®™]+)", "${m2}N'${value}");
            var unicodeStatement = GetEscapedQuery(query);
            return unicodeStatement;
        }

        public static string GetEscapedQuery(string query)
        {
            var scanner = new Scanner(new ParseOptions(false));
            scanner.SetSource(query, 0);
            var end = 0;
            var sb = new StringBuilder();
            while (end < query.Length)
            {
                var prevEnd = end;
                bool param, pairMatch;
                int start = 0, state = 0;
                scanner.GetNext(ref state, out start, out end, out pairMatch, out param);

                var token = SafeSubstring(query, start, end);
                if (token.StartsWith("'") && token.EndsWith("'"))
                {
                    token = string.Format("N{0}", token);
                }
                for (var i = (start - prevEnd - 1); i > 0; i--)
                {
                    sb.Append(" ");
                }
                sb.Append(token);
            }
            return sb.ToString();
        }

        private static string SafeSubstring(string text, int start, int end)
        {
            return start < text.Length ? text.Substring(start, (end - start + 1)) : string.Empty;
        }
    }
}
