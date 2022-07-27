using ElectronicsShop.Core.Enums;
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
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        [Required]
        public Role Role { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
