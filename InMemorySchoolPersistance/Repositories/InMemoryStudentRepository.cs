using SchoolModel.Entities;
using SchoolModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemorySchoolPersistance.Repositories
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private static long Lastid;

        private static Dictionary<long, Student> studentData = new Dictionary<long, Student>();
        static InMemoryStudentRepository ()
        {
            Student a = new Student()
            {
                Id = ++Lastid,
                Firstname = "riccardo",
                Lastname = "ciccio",
                Email = "riccardo@email.it",
                Address = "asklaskl",
                PhoneNumber = "065548666",
                SSN = "abce",
                StudentCode = "bca",
                IsEmployee = true,
            };

            studentData[a.Id] = a;

            Student b = new Student()
            {
                Id = ++Lastid,
                Firstname = "samu",
                Lastname = "pasticcio",
                Email = "samu@email.it",
                Address = "fdsfl",
                PhoneNumber = "331805555",
                SSN = "cde",
                StudentCode = "abc",
                IsEmployee = false,
            };

            studentData[b.Id] = b;

        }
        public Student Create(Student s)
        {
            studentData[s.Id]=s;
            return s;
        }

        public bool Delete(long key)
        {
            return studentData.Remove(key);
        }

        public bool Delete(Student element)
        {
            return studentData.Remove(element.Id);
        }

        public Student FindById(long id)
        {
            return studentData[id];   
        }

        public IEnumerable<Student> GetAll()
        {
            return studentData.Values;
        }

        public bool Update(Student newElement)
        {
            if (studentData.ContainsKey(newElement.Id))
            {
                studentData[newElement.Id] = newElement;
                return true;
            }
            return false;
        }
    }
}
