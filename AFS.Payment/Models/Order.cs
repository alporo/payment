using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AFS.Payment.Models
{
    public class Order
    {
        [Required]
        public Guid Id { get; set; }
        [DisplayName("Date of birth")]
        [Required]
        public string DateOfBirth { get; set; }
    }
}