using EFSchoolPersistence.EF;
using SchoolModel.Entities;
using SchoolModel.Repositories;
using SchoolModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolPersistence.Services
{
    public class EFDidatticService : IDidacticsService
    {
        private IStudentRepository studentRepo;
        private SchoolContext ctx;
        public EFDidatticService(IStudentRepository studentRepo, SchoolContext ctx) 
        {
            this.studentRepo = studentRepo;
            this.ctx = ctx;
        }

        public Student CreateStudent(Student s)
        {
            studentRepo.Create(s);
            ctx.SaveChanges(); //Salviamo qui invece che nella repository
            return s;
        }
        public IEnumerable<Student> GetStudentsByLastnameLike(string lastnameLike)
        {
            return studentRepo.FindByLastnameLike(lastnameLike).ToList(); //Non più una query, ma una lista vera e propria grazie a .ToList
        }
    }
}
