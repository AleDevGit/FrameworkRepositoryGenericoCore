using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkRepositoryGenerico.Repository.InterfaceRepositories
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll(string includes = null);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicade);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Save();

    }
}
