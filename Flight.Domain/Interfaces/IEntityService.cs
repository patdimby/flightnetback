using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight.Domain.Core.Abstracts;
using Flight.Domain.Entities;

namespace Flight.Domain.Interfaces
{
    public interface IEntityService<T, TKey> where T : class
    {
        Task<T> RetrieveAsync(TKey id);
        Task<List<T>> GetAllAsync();
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(TKey id);
    }
}
