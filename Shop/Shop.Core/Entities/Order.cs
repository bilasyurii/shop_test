using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Core.Entities
{
    public class Order : IEntity<int>
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Enter name")]
        [MaxLength(20, ErrorMessage = "Maximum length of a name is 5 symbols")]
        [MinLength(5, ErrorMessage = "Minimal length of a name is 5 symbols")]
        [Required(ErrorMessage = "Name can't be empty")]
        public string Name { get; set; }

        [Display(Name = "Enter surname")]
        [MaxLength(20, ErrorMessage = "Maximum length of a surname is 5 symbols")]
        [MinLength(5, ErrorMessage = "Minimal length of a surname is 5 symbols")]
        [Required(ErrorMessage = "Surname can't be empty")]
        public string Surname { get; set; }

        [Display(Name = "Enter address")]
        [MaxLength(20, ErrorMessage = "Maximum length of an address is 5 symbols")]
        [MinLength(5, ErrorMessage = "Minimal length of an address is 5 symbols")]
        [Required(ErrorMessage = "Address can't be empty")]
        public string Address { get; set; }

        [Display(Name = "Enter phone number")]
        [MaxLength(20, ErrorMessage = "Maximum length of a phone number is 5 symbols")]
        [MinLength(5, ErrorMessage = "Minimal length of a phone number is 5 symbols")]
        [Required(ErrorMessage = "Phone number can't be empty")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Enter email")]
        [MaxLength(20, ErrorMessage = "Maximum length of an email is 5 symbols")]
        [MinLength(5, ErrorMessage = "Minimal length of an email is 5 symbols")]
        [Required(ErrorMessage = "Email can't be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [BindNever]
        public DateTime OrderTime { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
