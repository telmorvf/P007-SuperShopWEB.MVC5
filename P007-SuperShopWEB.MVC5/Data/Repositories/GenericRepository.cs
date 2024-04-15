using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace P007_SuperShopWEB.MVC5.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;

        // 1 Constructor
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        // 2 GetAll - Todos os objetos do tipo Entitie
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>()
                .AsNoTracking();
        }

        // 3 Find - Only One item of GenericRepository
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        // 4 Add Product - only in the memory List
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveAllAsync();
        }

        // 5 Update Product
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveAllAsync();
        }

        // 6 Delete Product - only in the memory List
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveAllAsync();
        }

        // 7 SaveAll Products - only in the memory List
        private async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        // 8 return bool if exists - só la vai ver se o produto existe, e devlve a condição bool
        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id == id);
        }

    }
}