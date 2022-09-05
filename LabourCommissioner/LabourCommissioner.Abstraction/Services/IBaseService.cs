using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.Services
{
    public interface IBaseService<T>
    {
        Task<T> GetASync(long entityID);
        Task<IEnumerable<T>> GetAllASync();
        Task<long> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetListAsync();
    }
}
