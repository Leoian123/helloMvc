using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolModel.Entities
{
   public class Person
    {
        public long Id { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String SSN { get; set; }
        public String Address { get; set; }
    }
}
