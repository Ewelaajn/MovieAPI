using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Middleware.Extensions
{
    public static class StringExtensions
    {
        private const string Na = "N/A";
        public static bool IsNullOrNa(this string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Contains(Na))
                return true;
            return false;
        }
    }
}
