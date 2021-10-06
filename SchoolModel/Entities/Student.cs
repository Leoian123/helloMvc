using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolModel.Entities
{
    public class Student : Person
    {
        public String StudentCode { get; set; }
        public bool IsEmployee { get; set; }
    }
}
