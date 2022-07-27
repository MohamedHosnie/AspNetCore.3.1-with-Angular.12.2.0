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
        [StringLength(Shared.Consts.User.Username_MaximumLength, MinimumLength = Shared.Consts.User.Username_MinimumLength)]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [StringLength(Shared.Consts.User.FullName_MaximumLength, MinimumLength = Shared.Consts.User.FullName_MinimumLength)]
        [DataType(DataType.Text)]
        public string FullName { get; set; }
        [Required]
        [StringLength(Shared.Consts.User.FullAddress_MaximumLength, MinimumLength = Shared.Consts.User.FullAddress_MinimumLength)]
        [DataType(DataType.Text)]
        public string FullAddress { get; set; }
        [Required]
        [StringLength(Shared.Consts.User.Email_MaximumLength, MinimumLength = Shared.Consts.User.Email_MinimumLength)]
        [RegularExpression(Shared.Consts.User.Email_Regex)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(Shared.Consts.User.PhoneNumber_MaximumLength, MinimumLength = Shared.Consts.User.PhoneNumber_MinimumLength)]
        [RegularExpression(Shared.Consts.User.PhoneNumber_Regex)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(Shared.Consts.User.Password_MaximumLength, MinimumLength = Shared.Consts.User.Password_MinimumLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (BirthDate > DateTime.Now.AddYears(-13))
            {
                errors.Add(new ValidationResult($"{nameof(BirthDate)} error! age must be older than 13.", new List<string> { nameof(BirthDate) }));
            }
            return errors;
        }
    }
}
