using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.DataAccessLayer.Utils
{
    public interface IBaseRepository<Key, T, Result, Filter, Lov>
    {
        Task<Key> Create(T entity);
        Task Update(T entity);
        Task Delete(Key id);
        Task<List<Result>> ReadAll(Filter filter);
        Task<Result> Read(Key id);
        Task<List<Lov>> ReadLov();
    }
}
