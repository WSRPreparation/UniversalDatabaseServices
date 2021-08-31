using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace UniversalDatabaseServices.DataServices
{
    public class UniversalDataService<T> : IUniversalDataService<T> where T : class, IDatabaseBaseObject
    {
        private readonly DbContext context;

        public UniversalDataService(DbContext context)
            => this.context = context;

        public async Task<T> Create(T entity)
        {
            var result = context.Set<T>().Add(entity);
            await context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> Delete(object uID, T entity)
        {
            if (entity == null)
                entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == uID);

            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<T> Get(object uID)
        {
            var result = await context.Set<T>().FirstOrDefaultAsync(ent => ent.Id == uID);

            return result;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await context.Set<T>().ToListAsync();

            return result;
        }

        public async Task<T> Update(object uID, T entity)
        {
            entity.Id = uID;
            context.Set<T>().AddOrUpdate(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
