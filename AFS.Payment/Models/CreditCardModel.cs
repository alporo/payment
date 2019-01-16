using System;
using System.ComponentModel.DataAnnotations;

namespace AFS.Payment.Models
{
    public class CreditCardModel
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "Field is required"), MinLength(15, ErrorMessage = "Minimum 19 digits"), MaxLength(19, ErrorMessage = "Maximum 19 digits")]
        public string Number { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}