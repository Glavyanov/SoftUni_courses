using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace Watchlist.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
            {
                decimal actualValue = 0M;
                bool succes = false;

                try
                {
                    string decValue = valueResult.FirstValue;
                    decValue = decValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decValue = decValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    actualValue = Convert.ToDecimal(decValue, CultureInfo.CurrentCulture);
                    succes = true;
                }
                catch (FormatException fex)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fex, bindingContext.ModelMetadata);
                }
                if (succes)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualValue);
                }
            }

            return Task.CompletedTask;
        }
    }
}