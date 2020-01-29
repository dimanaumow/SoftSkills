using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MiniRefection
{
    public static class Extension
    {
        private const char vertical = '|';
        private const char horizontal = '-'; 
        private static Dictionary<string, int> columnsLength; 
        public static void ToTableView<T>(this IEnumerable<T> source, TextWriter writer)
        {
            Type type = typeof(T);
            var headers = type.GetProperties().Select(p => p.Name).ToArray();
            CreateColumnsLength(source, headers);
            var sumColumnLength = columnsLength.Select(s => s.Value).Sum()
                + columnsLength.Count + 1;
          
            writer.WriteLine(new string(Enumerable.Repeat(horizontal, sumColumnLength).ToArray()));
            foreach (var column in columnsLength)
            {
                writer.Write($"{vertical}{column.Key.PadLeft(column.Value)}");
            }
            writer.WriteLine(vertical);
            writer.WriteLine(new string(Enumerable.Repeat(horizontal, sumColumnLength).ToArray()));
            foreach (var item in source)
            {
                foreach (var column in columnsLength)
                {
                    string s = typeof(T).GetProperty(column.Key)?.GetMethod.Invoke(item, null).ToString();
                    writer.Write($"{vertical}{s.PadLeft(column.Value)}");
                }
                writer.WriteLine();
                writer.WriteLine(new string(Enumerable.Repeat(horizontal, sumColumnLength).ToArray()));
            }
        }
        private static void CreateColumnsLength<T>(IEnumerable<T> source,
            IEnumerable<string> headers)
        {
            columnsLength = new Dictionary<string, int>();
            foreach (var header in headers)
            {
                var max = source.
                    Select(s => typeof(T).GetProperty(header)?.GetMethod.
                    Invoke(s, null).
                    ToString().Length).
                    Max();
                columnsLength[header] = max ?? 0;
            }
        }
    }
}