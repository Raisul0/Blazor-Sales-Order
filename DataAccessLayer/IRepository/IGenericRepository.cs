using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        //T GetById(int id);
        Task<T> GetByIdAsync(int id);
        //List<T> GetAll();
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllWithRelationalObjects(params string[] includes);
        Task<List<T>> GetAllTrueWithRelationalObjects(Expression<Func<T, bool>> expression, params string[] includes);
        Task<T> GetWithRelationalObjects(Expression<Func<T, bool>> expression, params string[] includes);

        Task<List<T>> Find(Expression<Func<T, bool>> expression);
        Task<T> FindFirst(Expression<Func<T, bool>> expression);
        Task<T> FindOrderByExpressionDesc<TKey>(Expression<Func<T, TKey>> sortCondition);

        //void Add(T entity);
        Task<T> AddAsync(T entity);
        T Add(T entity);

        //void AddRange(List<T> entities);
        Task<List<T>> AddRangeAsync(List<T> entities);

        void Remove(T entity);
        void RemoveRange(List<T> entities);
    }
}
