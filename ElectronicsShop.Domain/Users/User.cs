using ElectronicsShop.Shared.Enums;
using ElectronicsShop.Domain.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectronicsShop.Domain.Users
{
    [Table("User")]
    public class User : Entity<int>
    {
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
        [StringLength(Shared.Consts.User.Email_MaximumLength, MinimumLength = Shared.Consts.User.Email_MaximumLength)]
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
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        [Required]
        public Role Role { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
