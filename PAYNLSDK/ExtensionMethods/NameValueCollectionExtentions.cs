using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace PayNLSdk.ExtensionMethods
{
    /// <summary>
    /// Extension methods for NameValueCollection
    /// </summary>
    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Convert a <see cref="NameValueCollection"/> to a <see cref="Dictionary{TKey,TValue}"/>
        /// </summary>
        /// <param name="nvc">in input</param>
        /// <param name="handleMultipleValuesPerKey">this will convert the values in a string[]</param>
        /// <returns></returns>
        public static Dictionary<string, object> ToDictionary(this NameValueCollection nvc, bool handleMultipleValuesPerKey = true)
        {
            var result = new Dictionary<string, object>();
            foreach (string key in nvc.Keys)
            {
                if (handleMultipleValuesPerKey)
                {
                    var values = nvc.GetValues(key);
                    if (values == null)
                    {
                        continue;
                    }

                    if (values.Length == 1)
                    {
                        result.Add(key, values[0]);
                    }
                    else
                    {
                        result.Add(key, values);
                    }
                }
                else
                {
                    result.Add(key, nvc[key]);
                }
            }

            return result;
        }
    }
}
