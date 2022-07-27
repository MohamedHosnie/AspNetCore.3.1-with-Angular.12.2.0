using ElectronicsShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectronicsShop.Application.Users.Dtos
{
    public class UserDto : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6)]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 6)]
        [DataType(DataType.Text)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Text)]
        public string FullAddress { get; set; }
        [Required]
        [StringLength(254, MinimumLength = 6)]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6)]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (BirthDate > DateTime.Now.AddYears(13))
            {
                errors.Add(new ValidationResult($"{nameof(BirthDate)} error! age must be older than 13.", new List<string> { nameof(BirthDate) }));
            }
            return errors;
        }
    }
}
