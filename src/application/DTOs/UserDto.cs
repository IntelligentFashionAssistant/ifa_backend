using System;
using System.Collections.Generic;
using domain.Entitys;

namespace application.DTOs
{
    public class UserDto
    {
        public long Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
    }
}