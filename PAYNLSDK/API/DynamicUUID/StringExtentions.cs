using System;
using System.Collections.Generic;
using System.Text;

namespace PayNLSdk.API.DynamicUUID
{
    public static class StringExtensions
    {
        public static string ToHex(this string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
                sb.AppendFormat("0x{0:X2} ", (int)c);
            return sb.ToString().Trim();
        }
    }
}
