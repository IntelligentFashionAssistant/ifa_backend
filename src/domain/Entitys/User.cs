using System;
using System.Collections.Generic;


namespace domain.Entitys
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<PropertyFeedback> PropertyFeedbacks { get; set; }

        //Constracter
        public User()
        {
            PropertyFeedbacks = new HashSet<PropertyFeedback>();
        }
    }
}
