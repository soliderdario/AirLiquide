using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Air.Liquide.Domain.Interface;
using Air.Liquide.Domain;

namespace Air.Liquide.Data.Repository
{
    public class Repository<TModel> : BaseRpository, IRepository<TModel> where TModel : BaseModel, new()
    {
        protected readonly DbSet<TModel> DbSet;
        public Repository(Context db) : base(db)
        {
            DbSet = db.Set<TModel>();
        }

        public virtual async Task Insert(TModel model)
        {
            DbSet.Add(model);
            await SaveChanges();
        }

        public virtual async Task Update(TModel model)
        {
            DbSet.Update(model);
            await SaveChanges();
        }

        public virtual async Task Delete(TModel model)
        {
            DbSet.Remove(model);
            await SaveChanges();
        }
        public virtual async Task<List<TModel>> List()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TModel>> Query(Expression<Func<TModel, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
