using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASHEmployee.Data
{
   public interface IRepository<T> where T :class ,IEntity
    {
        public Task<List<T>> GetAll();
        public Task<T> Get(int id);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(int id);
    }
}
