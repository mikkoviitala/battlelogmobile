using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattlelogMobile.Core.Service
{
    public static class EnumHelper
    {
        public static IEnumerable<T> GetEnumValues<T>()
        {
            return typeof(T)
                .GetFields()
                .Where(x => x.IsLiteral)
                .Select(field => (T)field.GetValue(null));
        }
    }
}
