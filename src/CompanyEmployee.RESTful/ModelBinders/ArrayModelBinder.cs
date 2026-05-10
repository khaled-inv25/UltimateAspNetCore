using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CompanyEmployee.RESTful.ModelBinders
{
    public class ArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
