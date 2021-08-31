using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalDatabaseServices.DataServices
{
    public interface IUniversalDataService<T> where T : class, IDatabaseBaseObject
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(object uID);

        Task<T> Create(T entity);

        Task<T> Update(object uID, T entity);

        Task<bool> Delete(object uID, T entity);
    }
}
