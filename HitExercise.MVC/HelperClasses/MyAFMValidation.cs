using HitExercise.DataAccess.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HitExercise.MVC.HelperClasses
{
    public sealed class MyAFMValidation : ValidationAttribute
    {
        

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (MyValidation.ValidateAFM(value.ToString()))
                    return ValidationResult.Success;
            }

            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }


        

        
    }
}