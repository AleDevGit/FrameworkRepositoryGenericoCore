using FrameworkRepositoryGenerico.Data.ModelsCadastro;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FrameworkRepositoryGenerico.Repository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {

        private bool SaveChanges = true;
        private readonly MyCadastroContext Context;

        public Repository(MyCadastroContext context, bool saveChanges = true)
        {
            SaveChanges = saveChanges;
            Context = context;
        }



        public TEntity Get(int id)
            => Context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll(string includes = "")
        {
            var ContextInclude = GetAllInclude(includes);

            return ContextInclude.ToList();
        }



        public IQueryable<TEntity> GetAllInclude(string includeProperties = "")
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();

            foreach (var includeExpression in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                set = set.Include(includeExpression);
            }
            return set;
        }




        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicade)
            => Context.Set<TEntity>().Where(predicade).ToList();


        public void Add(TEntity entity)
            => Context.Set<TEntity>().Add(entity);


        public void AddRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().AddRange(entities);


        public void Update(TEntity entity)
            => Context.Set<TEntity>().Attach(entity);


        public void UpdateRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().AttachRange(entities);


        public void Remove(TEntity entity)
            => Context.Set<TEntity>().Remove(entity);


        public void RemoveRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().RemoveRange(entities);

        public void Save() => Context.SaveChanges();

        public void Dispose() => Context.Dispose();


    }
}
