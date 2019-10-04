using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DiamondPriceCalculator.Web
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            DisplayAttribute attribute = GetDisplayAttribute(value);
            return attribute?.Name ?? value.ToString();
        }

        public static string GetGroupName(this Enum value)
        {
            DisplayAttribute attribute = GetDisplayAttribute(value);
            return attribute?.GroupName ?? string.Empty;
        }

        private static DisplayAttribute GetDisplayAttribute(Enum value)
        {
            var enumName = value.ToString();
            var enumType = value.GetType();
            var fieldInfo = enumType.GetField(enumName);
            return fieldInfo.GetCustomAttribute<DisplayAttribute>();
        }
    }
}
