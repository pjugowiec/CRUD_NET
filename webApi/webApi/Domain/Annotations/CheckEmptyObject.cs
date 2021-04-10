using System;
using System.ComponentModel.DataAnnotations;

namespace webApi.Domain.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class CheckEmptyObject : ValidationAttribute
    {
        private readonly Object _objectToCheck;
        public CheckEmptyObject(Object objectToCheck)
        {
            _objectToCheck = objectToCheck;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return value == null ? new ValidationResult("") : ValidationResult.Success;
        }
    }
}
