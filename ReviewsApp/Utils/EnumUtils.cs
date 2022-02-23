using System;
using System.Collections.Generic;
using System.Linq;

namespace ReviewsApp.Utils
{
    public static class EnumUtils
    {
        public static IEnumerable<T> GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
