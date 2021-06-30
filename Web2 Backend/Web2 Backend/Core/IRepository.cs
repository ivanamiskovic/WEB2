using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web2_Backend.Model;

namespace Web2_Backend.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(long d);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        PageResponse<TEntity> GetAll(int page, int perPage, string search, string sort);
        IEnumerable<Entity> Search(string term = "");

        PageResponse<TEntity> GetPage(PageModel model);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void Detach(TEntity entity);

    }
}
