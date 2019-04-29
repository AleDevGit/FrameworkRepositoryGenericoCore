using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FrameworkRepositoryGenerico.Repository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {

        private bool SaveChanges = true;
        private readonly MyCadastroContext Context;

        public Repository(MyCadastroContext context , bool saveChanges = true)
        {
            SaveChanges = saveChanges;
            Context = context;
        }
        
        
        public TEntity Get(int id) 
            => Context.Set<TEntity>().Find(id);
            
        public IEnumerable<TEntity> GetAll()
            => Context.Set<TEntity>().ToList();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicade) 
            => Context.Set<TEntity>().Where(predicade).ToList();
                       
        public void Add(TEntity entity) 
            => Context.Set<TEntity>().Add(entity);


        public void AddRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().AddRange(entities);


        public void Update (TEntity entity) 
            => Context.Set<TEntity>().Attach(entity);


        public void UpdateRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().AttachRange(entities);


        public void Remove(TEntity entity) 
            => Context.Set<TEntity>().Remove(entity);


        public void RemoveRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().RemoveRange(entities);

        public void Save() => Context.SaveChanges();

        public void Dispose() => Context.Dispose();



        //Com Includes
        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] include)
        {
            try
            {
                if (include.Length == 0)
                    throw new Exception("Número de parametros inválido.");

                var query = Context.Set<TEntity>().AsQueryable();

                query = include.Aggregate(query, (current, exp) => current.Include(exp));

                IEnumerable<TEntity> result = query.ToList();
                return result;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }



        public IQueryable<TEntity> GetAllIncludes(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            return includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(Context.Set<TEntity>(), (current, expression) => current.Include(expression));
        }




    }
}
