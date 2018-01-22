using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string scode = "1234";

            string scodeInput = value as string;

            if (scodeInput != scode)
            {
                return new ValidationResult("The secred code is not correct");
            }

            return ValidationResult.Success;
        }
    }
}
