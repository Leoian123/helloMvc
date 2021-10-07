using EFSchoolPersistence.EF;
using SchoolModel.Entities;
using SchoolModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolPersistence.Repository {
    public class EFStudentRepository : EFCrudRepository<Student,long> , IStudentRepository
    {
        public EFStudentRepository(SchoolContext ctx) : base(ctx)
        {

        }
        public IEnumerable<Student> FindByLastnameLike(string lastnameLike)
        {
            return ctx.Students.Where(a => a.Lastname.Contains(lastnameLike));
        }
    }
}
