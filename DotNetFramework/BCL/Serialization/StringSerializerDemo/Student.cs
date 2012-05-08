using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedClasses
{
    public class Address
    {
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
    }

    public class Student
    {
        private Address addr;

        public Student() 
        {
            addr = new Address();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public DateTime Birthday { get; set; }
        public Address Addr 
        {
            get { return addr; }
            set { addr = value; }
        }
    }

    public class TestData
    {
        public static Student CreateStudent()
        {
            var obj = new SharedClasses.Student()
            {
                ID = 100,
                Name = "Michael Tsai",
                Sex = true,
                Birthday = DateTime.Now,
            };

            obj.Addr.Country = "US";
            obj.Addr.City = "New Jersey";
            obj.Addr.Street1 = "310 Keasbey";

            return obj;
        }
    }
}
