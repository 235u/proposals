using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IdentityCustomization.Helpers
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            FieldInfo field = GetFieldInfo(value);
            DisplayAttribute attribute = field.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name ?? value.ToString();
        }

        private static FieldInfo GetFieldInfo(Enum value)
        {
            string enumName = value.ToString();
            Type enumType = value.GetType();
            return enumType.GetField(enumName);
        }
    }
}
