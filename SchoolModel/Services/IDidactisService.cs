using SchoolModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolModel.Services
{
    public interface IDidactisService
    {
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetStudentsByLastnameLike(string lastnameLike);
        Student CreateStudent(Student s);
        Student GetStudentById(long id);
        void UpdateStudent(Student s);
        void Delete(Student s);
    }

}
