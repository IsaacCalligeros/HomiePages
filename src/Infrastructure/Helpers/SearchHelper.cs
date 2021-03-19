using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HomiePages.Infrastructure.Helpers
{
    public static class SearchHelper
    {
        public static List<T> KeySearch<T>(this List<T> data, string key, string searchString, bool equals = true)
        {
            var property = typeof(T).GetProperty(key, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);

            if (property == null)
                throw new ArgumentException($"'{typeof(T).Name}' does not implement a public get property named '{key}'.");

            var res = equals ? data.Where(d => property.GetValue(d).Equals(searchString)).ToList() : data.Where(d => ((string)property.GetValue(d)).Contains(searchString)).ToList();
            return res;
        }

        public static List<T> ContainsSearch<T>(this List<T> data, string searchString)
        {
            var containsList = new List<T>();
            foreach (var property in typeof(T).GetProperties())
            {
                //property.PropertyType == typeof(DateTime) ? property.GetValue(d).ToString() : 
                foreach (var item in data)
                {
                    var stringForm = property.GetValue(item) != null ? property.GetValue(item).ToString() : string.Empty;
                    if (stringForm.Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
                    {
                        containsList.Add(item);
                    }
                }
                //containsList.AddRange(data.Where(d => (property.GetValue(d)?.ToString()).Contains(searchString)).ToList());
            }
            return containsList.Distinct().ToList();
        }
    }
}
