
using BOL;
using BOL.Core;
using BOL.Core.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        
        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public T SingleOrDefault(Expression<Func<T, bool>> whereCondition)
        {
            var dbResult = Context.Set<T>().Where(whereCondition).FirstOrDefault();
            return dbResult;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return Context.Set<T>().Where(whereCondition).AsEnumerable();
        }

        public virtual T Insert(T entity)
        {

            dynamic obj = Context.Set<T>().Add(entity);
            return obj;

        }

        public virtual void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateAll(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                Context.Set<T>().Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }
        
        public void Delete(Expression<Func<T, bool>> whereCondition)
        {
            IEnumerable<T> entities = this.GetAll(whereCondition);
            foreach (T entity in entities)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    Context.Set<T>().Attach(entity);
                }
                Context.Set<T>().Remove(entity);
            }
        }

        //--------------Exra generic methods--------------------------------

        public T SingleOrDefaultOrderBy(Expression<Func<T, bool>> whereCondition, Expression<Func<T, int>> orderBy, string direction)
        {
            if (direction == "ASC")
            {
                return Context.Set<T>().Where(whereCondition).OrderBy(orderBy).FirstOrDefault();

            }
            else
            {
                return Context.Set<T>().Where(whereCondition).OrderByDescending(orderBy).FirstOrDefault();
            }
        }

        public bool Exists(Expression<Func<T, bool>> whereCondition)
        {
            return Context.Set<T>().Any(whereCondition);
        }

        public int Count(Expression<Func<T, bool>> whereCondition)
        {
            return Context.Set<T>().Where(whereCondition).Count();
        }

        public IEnumerable<T> GetPagedRecords(Expression<Func<T, bool>> whereCondition, Expression<Func<T, string>> orderBy, int pageNo, int pageSize)
        {
            return (Context.Set<T>().Where(whereCondition).OrderBy(orderBy).Skip((pageNo - 1) * pageSize).Take(pageSize)).AsEnumerable();
        }

        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return Context.Set<T>().SqlQuery(query, parameters);
        }
    }
}