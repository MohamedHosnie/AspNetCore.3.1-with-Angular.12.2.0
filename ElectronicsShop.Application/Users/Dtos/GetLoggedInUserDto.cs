using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Application.Users.Dtos
{
    public class GetLoggedInUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string FullAddress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Role { get; set; }
    }
}
