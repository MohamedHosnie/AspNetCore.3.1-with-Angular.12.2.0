using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Application.Auth.Dtos
{
    public class LoginDto
    {
        [Required]
        [StringLength(Shared.Consts.User.Username_MaximumLength, MinimumLength = Shared.Consts.User.Username_MinimumLength)]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [StringLength(Shared.Consts.User.Password_MaximumLength, MinimumLength = Shared.Consts.User.Password_MinimumLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
