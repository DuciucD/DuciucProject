using DuciucProject.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Linq;

namespace DuciucProject.Validators
{
    public class CustomModelValidatorProvider : IModelValidatorProvider
    {
        // Link : https://stackoverflow.com/questions/66489184/start-date-should-be-less-than-end-date-validation-in-asp-net-core-mvc

        public void CreateValidators(ModelValidatorProviderContext context)
        {
            if (context.Results.Any(v => v.Validator.GetType() == typeof(DateCustomDateValidator)) == true)
            {
                return;
            }

            if (context.ModelMetadata.ContainerType == typeof(Item) || context.ModelMetadata.ContainerType == typeof(Project))
            {
                context.Results.Add(new ValidatorItem
                {
                    Validator = new DateCustomDateValidator(),
                    IsReusable = true
                });
            }
        }
    }
}
