using System;
using System.Collections.Generic;
using domain.Entitys;

namespace application.DTOs
{
    public class UserDto
    {
        private long Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}