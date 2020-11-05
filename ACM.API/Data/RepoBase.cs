using System.Threading.Tasks;
using ACM.BL;

namespace ACM.API.Data
{
    public abstract class RepoBase
    {
        protected readonly DataContext _context;

        public RepoBase(DataContext context)
        {
            _context = context;
        }

          public virtual void add<T>(T entity) where T : class
        {
            _context.Add(entity);
            
        }
        public virtual void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            
        }
        public virtual async Task<bool> SaveAll()
        {
            // if we return more than 0 it returns true.
            return await _context.SaveChangesAsync() > 0;
        }

    }
}