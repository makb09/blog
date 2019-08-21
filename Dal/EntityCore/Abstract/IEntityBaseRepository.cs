using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dal.EntityCore.Abstract
{
    public interface IEntityBaseRepository<T> where T : class, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll();

        int Count();

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        IQueryable<T> FromSql(string query);

        IDbContextTransaction BeginTransaction();


        bool IsHaveForeign(T entity);

        void Add(T entity);

        Task<EntityEntry<T>> AddAsync(T entity);

        void AddRange(IEnumerable<T> entityList);

        Task AddRangeAsync(IEnumerable<T> entityList);

        void Update(T entity, params Expression<Func<T, object>>[] updatedProperties);

        void Delete(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);

        void Commit();

        Task<int> CommitAsync();

        void BulkInsert(IList<T> entityList);

        void BulkUpdate(IList<T> entityList);

        void BulkInsertOrUpdate(IList<T> entityList);

        void BulkDelete(IList<T> entityList);
    }
}