using EFSchoolPersistence.EF;
using Microsoft.EntityFrameworkCore;
using SchoolModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolPersistence.Repository
{
    public class EFCrudRepository<T, K> : ICrudRepository<T, K> where T : class
    {
        protected readonly SchoolContext ctx;
        private DbSet<T> entities;
        public EFCrudRepository(SchoolContext ctx)
        {
            this.ctx = ctx;
            this.entities = ctx.Set<T>();
        }
        public T Create(T newElement)
        {
            entities.Add(newElement);
            //ctx.SaveChanges();  Non salviamo qui, ma in DidacticsService
            return newElement;
        }

        public void Delete(K id)
        {
            T found = entities.Find(id);
            //if (found == null)
            //{
            //    return false;
            //}
            entities.Remove(found);
            //ctx.SaveChanges();
            //return true;
        }
        public void Delete(T element)
        {
            entities.Remove(element);

            //int changes = ctx.SaveChanges();
            //if (changes == 0)
            //{
            //    return false;
            //}
            //return true;

        }

        public T FindById(K id)
        {
            return entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Update(T newElement)
        {
            entities.Update(newElement);
            //int numChanges = ctx.SaveChanges();
            //return numChanges > 0;
        }
    }
}
