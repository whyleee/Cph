using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cph.Aids
{
    public class FormattedDateTimeModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var displayFormat = bindingContext.ModelMetadata.DisplayFormatString;
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (!string.IsNullOrEmpty(displayFormat) && value != null && !string.IsNullOrEmpty(value.AttemptedValue))
            {
                DateTime date;
                displayFormat = displayFormat.Replace("{0:", "").Replace("}", "");
                // use the format specified in the DisplayFormat attribute to parse the date
                if (DateTime.TryParseExact(value.AttemptedValue, displayFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
                
                bindingContext.ModelState.AddModelError(
                    key: bindingContext.ModelName,
                    errorMessage: string.Format("{0} is an invalid date format", value.AttemptedValue)
                );
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}