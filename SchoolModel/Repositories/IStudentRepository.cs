using SchoolModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolModel.Repositories
{
    public interface IStudentRepository
    {
        Student FindbyId(long id);
        IEnumerable<Student> GetAll();
        Student Add(Student s);
    }
}
