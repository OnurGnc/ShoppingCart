using CartContract.Interface;
using CartData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartContract.Abstract
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CartContext _context;

        public Repository(CartContext context)
        {
            _context = context;
        }

        public virtual void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(int id)
        {
            T entity = GetById(id);
            _context.Set<T>().Remove(entity);
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
