using SchoolModel.Entities;
using SchoolModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolPersistence.Repository
{
    public class EFStudentRepository : IStudentRepository
    {
        public Student Add(Student s)
        {
            throw new NotImplementedException();
        }

        public Student FindbyId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
