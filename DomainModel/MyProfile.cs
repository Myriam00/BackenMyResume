using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
   public class MyProfile
    {
        public int MyProfileID { get; set; }
        public String Firstname { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String Function { get; set; }

    }
}
