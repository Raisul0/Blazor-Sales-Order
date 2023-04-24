
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllWithRelationalObjects(params string[] includes)
        {
            var values = _context.Set<T>().AsQueryable<T>();

            foreach(var include in includes)
            {
                values = values.Include(include);
            }

            return await values.ToListAsync();
        }

        public async Task<List<T>> GetAllTrueWithRelationalObjects(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var values = _context.Set<T>().AsQueryable<T>();

            foreach (var include in includes)
            {
                values = values.Include(include);
            }

            return await values.Where(expression).ToListAsync();
        }

        public async Task<T> GetWithRelationalObjects(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var values = _context.Set<T>().AsQueryable<T>();

            foreach (var include in includes)
            {
                values = values.Include(include);
            }

            return await values.FirstOrDefaultAsync(expression);
        }

        public async Task<T>  AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public Task<List<T>> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToListAsync();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<T> FindFirst(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T> FindOrderByExpressionDesc<TKey>(Expression<Func<T, TKey>> sortCondition)
        {
            return await _context.Set<T>().OrderByDescending(sortCondition).FirstOrDefaultAsync();
        }



    }
}
