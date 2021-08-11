using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Fiba.BL.Helpers
{
	public class ArrayModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			// only on enumerable types
			if (!bindingContext.ModelMetadata.IsEnumerableType)
			{
				bindingContext.Result = ModelBindingResult.Failed();
				return Task.CompletedTask;
			}

			// get the inputted value through the value provider
			var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();

			// value null return null
			if (string.IsNullOrWhiteSpace(value))
			{
				bindingContext.Result = ModelBindingResult.Success(null);
				return Task.CompletedTask;
			}

			// value isn't null or whitespace,
			// and the type of the model is enumerable
			// get the enumerable's type, and a convert
			var elementType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];
			var converter = TypeDescriptor.GetConverter(elementType);

			// convert each item in the value list to the enumerable type
			var values = value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => converter.ConvertFromString(x.Trim()))
				.ToArray();

			// create an array of that type, and set it as the Model value
			var typedValues = Array.CreateInstance(elementType, values.Length);
			values.CopyTo(typedValues, 0);
			bindingContext.Model = typedValues;

			// return a successful result, passing in the Model
			bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
			return Task.CompletedTask;
		}
	}
}
