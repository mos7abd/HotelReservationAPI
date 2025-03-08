using HotelReservationAPI.Data;
using HotelReservationAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace HotelReservationAPI.Repositoried
{
    public class GeneralRepository<T> where T : BaseModel
    {
        protected Context _context;
        protected DbSet<T> _dbSet;

        public GeneralRepository()
        {
            _context = new Context();
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public async Task<T> GetByID(int id)
        {
            return await _dbSet
                .Where(c => c.ID == id)
                .FirstOrDefaultAsync();
        }

        public async Task<T> GetByIDWithTracking(int id)
        {
            return await _dbSet
                .Where(c => c.ID == id)
                .AsTracking()
                .AsQueryable()
                .FirstOrDefaultAsync();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            var crs = await GetByIDWithTracking(id);
            crs.Deleted = true;
            _context.SaveChanges();
        }

        public void UpdateInclude(T entity, params string[] modifiedProperties)
        {
            if (!_dbSet.Any(x => x.ID == entity.ID))
                return;

            var local = _dbSet.Local.FirstOrDefault(x => x.ID == entity.ID);
            EntityEntry entityEntry;

            if (local is null)
                entityEntry = _context.Entry(entity);
            else
                entityEntry = _context.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity.ID == entity.ID);


            foreach (var prop in entityEntry.Properties)
            {
                if (modifiedProperties.Contains(prop.Metadata.Name))
                {
                    prop.CurrentValue = entity.GetType().GetProperty(prop.Metadata.Name).GetValue(entity);
                    prop.IsModified = true;
                }
            }

            _context.SaveChanges();
        }
    }
}
