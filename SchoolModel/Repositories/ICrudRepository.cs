using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolModel.Repositories {
    public interface ICrudRepository<T, K> {
        T Create(T newElement);
        bool Delete(T element);
        bool Delete(K key);
        bool Update(T newElement);
        T FindById(K key);
        IEnumerable<T> GetAll();
    }
}
