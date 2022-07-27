using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectronicsShop.Application.Auth.Dtos
{
    public class LoginDto
    {
        [Required]
        [StringLength(15, MinimumLength = 6)]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
