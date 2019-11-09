using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace IdentityCustomization.Helpers
{
    public static class SelectListHelper
    {
        public static IEnumerable<SelectListItem> CreateSelectListItems<TEnum>()
            where TEnum : Enum
        {
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum))
                .OfType<TEnum>()
                .ToList();

            return CreateSelectListItems(values);
        }

        private static IEnumerable<SelectListItem> CreateSelectListItems<TEnum>(IEnumerable<TEnum> values)
            where TEnum : Enum
        {
            Type enumType = Enum.GetUnderlyingType(typeof(TEnum));
            return values.Select(value => new SelectListItem()
            {
                Text = value.GetDisplayName(),
                Value = Convert.ChangeType(value, enumType, CultureInfo.InvariantCulture).ToString()
            });
        }
    }
}
