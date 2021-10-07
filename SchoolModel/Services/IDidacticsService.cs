using SchoolModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolModel.Services
{
    public interface IDidacticsService
    {
        IEnumerable<Student> GetStudentsByLastnameLike(string lastnameLike);
        Student CreateStudent(Student s);
    }

}
