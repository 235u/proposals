using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SteamPriceComparison.Helpers
{
    public static class DisplayAttributeHelper
    {
        public static string GetName(Enum value)
        {
            DisplayAttribute attribute = GetDisplayAttribute(value);
            return attribute?.Name ?? value.ToString();
        }

        public static string GetShortName(Enum value)
        {
            DisplayAttribute attribute = GetDisplayAttribute(value);
            return attribute?.ShortName ?? value.ToString();
        }

        private static DisplayAttribute GetDisplayAttribute(Enum value)
        {
            FieldInfo field = GetFieldInfo(value);
            DisplayAttribute attribute = field.GetCustomAttribute<DisplayAttribute>();
            return attribute;
        }

        private static FieldInfo GetFieldInfo(Enum value)
        {
            string enumName = value.ToString();
            Type enumType = value.GetType();
            return enumType.GetField(enumName);
        }
    }
}
