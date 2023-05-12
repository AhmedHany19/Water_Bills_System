using Domain.IRepositiory;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositiory
{
    public class BaseRepositiory<T> : IBaseRepositiory<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepositiory(ApplicationDbContext context)
        {
            _context = context;

        }
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }
        public T Add(T entity)
        {
            try
            {

                _context.Set<T>().Add(entity);
                return entity;

            }
            catch (Exception)
            {

                return null;
            }
        }
        public int Count()
        {
            try
            {
                return _context.Set<T>().Count();
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T Find(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>().Where(predicate);
                if (includes != null)
                {
                    foreach (var include in includes)
                        query = query.Include(include);
                }
                return query.FirstOrDefault(predicate);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();

                if (includes != null)
                {
                    foreach (var include in includes)
                        query = query.Include(include);
                }
                return query.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public T GetById(string code)
        {
            try
            {
                return _context.Set<T>().Find(code);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<T> GetByIdAsync(string code)
        {
            try
            {
                return await _context.Set<T>().FindAsync(code);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public T Update(T entity)
        {
            try
            {
                _context.Update(entity);
                return entity;             

            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                query = query.Where(criteria);

                if (includes != null)
                {
                    foreach (var include in includes)
                        query = query.Include(include);
                }
                return query.Where(criteria).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
