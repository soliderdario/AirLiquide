using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Air.Liquide.Domain.Interface
{
    public interface IRepository<TModel> : IDisposable where TModel : BaseModel
    {
        Task Insert(TModel model);
        Task Update(TModel model);
        Task Delete(TModel model);
        Task<List<TModel>> List();
        Task<IEnumerable<TModel>> Query(Expression<Func<TModel, bool>> predicate);
        Task<int> SaveChanges();
    }
}
