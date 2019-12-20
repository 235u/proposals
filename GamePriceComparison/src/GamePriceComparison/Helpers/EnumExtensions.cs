using System;

namespace GamePriceComparison.Helpers
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum value)
        {
            return DisplayAttributeHelper.GetName(value);
        }

        public static string GetShortName(this Enum value)
        {
            return DisplayAttributeHelper.GetShortName(value);
        }
    }
}
