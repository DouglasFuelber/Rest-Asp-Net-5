using Microsoft.EntityFrameworkCore;
using RestAspNet5.Model.Base;
using RestAspNet5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAspNet5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            T itemDb = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (itemDb != null)
            {
                try
                {
                    _context.Entry(itemDb).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            T item = dataset.SingleOrDefault(i => i.Id.Equals(id));

            if (item != null)
            {
                try
                {
                    dataset.Remove(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
