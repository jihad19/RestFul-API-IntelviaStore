using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelviaStore.Services
{
    public interface ICrudService<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int Id);
        Task<T> Create(T Model);
        Task Update(T Model);
        Task Delete(int Id);
    }
}
