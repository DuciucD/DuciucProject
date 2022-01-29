using DuciucProject.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuciucProject.Validators
{
    public class DateCustomDateValidator : IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            Item itemModel = context.Container as Item;

            if (itemModel != null)
            {
                if (context.ModelMetadata.ModelType == typeof(DateTime)
                    && context.ModelMetadata.Name == nameof(itemModel.StartDate))
                {

                    if (itemModel.StartDate > itemModel.DueDate)
                    {
                        return new List<ModelValidationResult>
                {
                   new ModelValidationResult("","Start Date should be less than Due date")
                };
                    }
                }
                if (context.ModelMetadata.ModelType == typeof(DateTime)
                    && context.ModelMetadata.Name == nameof(itemModel.DueDate))
                {

                    if (itemModel.DueDate < itemModel.StartDate)
                    {
                        return new List<ModelValidationResult>
                {
                   new ModelValidationResult("","due Date should be grater than Start date")
                };
                    }
                }
            }
            else
            {
                Project projectModel = context.Container as Project;

                if (projectModel != null)
                {
                    if (context.ModelMetadata.ModelType == typeof(DateTime)
                        && context.ModelMetadata.Name == nameof(projectModel.StartDate))
                    {

                        if (projectModel.StartDate > projectModel.EndDate)
                        {
                            return new List<ModelValidationResult>
                {
                   new ModelValidationResult("","Start Date should be less than End date")
                };
                        }
                    }
                    if (context.ModelMetadata.ModelType == typeof(DateTime)
                        && context.ModelMetadata.Name == nameof(projectModel.EndDate))
                    {

                        if (projectModel.EndDate < projectModel.StartDate)
                        {
                            return new List<ModelValidationResult>
                {
                   new ModelValidationResult("","End Date should be grater than Start date")
                };
                        }
                    }
                }
            }

            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}
