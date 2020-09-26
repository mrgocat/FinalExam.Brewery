using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Brewery.DataAccessLayer
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private readonly BreweryContext _context;

        /*public EFGenericRepository(BreweryContext context)
        {
            _context = context;
        }*/
        public EFGenericRepository()
        {
            _context = new BreweryContext();
        }
        public void Add(params T[] items)
        {

            _context.Set<T>().AddRange(items);
            _context.SaveChanges();
        }
        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }
        public void Update(params T[] items)
        {
            _context.Set<T>().UpdateRange(items);
            _context.SaveChanges();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = navigationProperties.Aggregate(query, (q, n) => q.Include(n));
            return query.ToList();

        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = navigationProperties.Aggregate(query, (q, n) => q.Include(n));
            return query.Where(where).ToList();

        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = navigationProperties.Aggregate(query, (q, n) => q.Include(n));
            return query.FirstOrDefault(where);
        }
    }
}
