using InventorySystem.DataAccess.Data;
using InventorySystem.DataAcess.Repository.IRepository;
using InventorySystem.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAcess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public  async Task Add(T entity)
        {
            await dbSet.AddAsync(entity); //insert into table
        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter); //select * from where ....
            }
            if(includeProperties != null)
            {
                foreach (var includProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includProp);  
                }
            }
            if(orderBy != null)
            {
                query = orderBy(query);
            }
            if(!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await dbSet.FindAsync(id); //select * from by ID only
        }

       

        public async Task<T> GetFirst(Expression<Func<T, bool>> filter = null, string includeProperties = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter); //select * from where ....
            }
            if (includeProperties != null)
            {
                foreach (var includProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includProp);
                }
            }
           
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRank(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
