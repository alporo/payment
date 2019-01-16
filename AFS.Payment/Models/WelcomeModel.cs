using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AFS.Payment.Utility;

namespace AFS.Payment.Models
{
    public class WelcomeModel
    {
        [Required] public Guid OrderId { get; set; }

        [DisplayName("Date of birth"), Required, ValidateDateFormat]
        public string DateOfBirthString { get; set; }

        public DateTime DateOfBirth => DateOfBirthString.TicksToDate().OrThrow(new Exception("Date invalid")).Date;
    }

    public class ValidateDateFormat : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) =>
            value.ToString().TicksToDate().HasValue() ? ValidationResult.Success : new ValidationResult("Date invalid");
    }
}