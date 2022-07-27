using ElectronicsShop.Shared.Enums;
using ElectronicsShop.Core.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectronicsShop.Core.Users
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
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(Shared.Consts.User.PhoneNumber_MaximumLength, MinimumLength = Shared.Consts.User.PhoneNumber_MinimumLength)]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$")]
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
