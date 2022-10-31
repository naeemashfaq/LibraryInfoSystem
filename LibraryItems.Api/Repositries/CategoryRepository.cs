using Microsoft.EntityFrameworkCore;
using LibraryItems.Api.Data;
using LibraryItems.Api.Entities;

namespace LibraryItems.Api.Repositries
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LibraryDbContext _context;

        public CategoryRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetItems()
        {
            try
            {
                var categories = await _context.Category.ToListAsync();
                return categories;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<Category> AddCategory(Category cat)
        {
            try
            {
                var dbCatName = await _context.Category.Where(x => x.CategoryName == cat.CategoryName).FirstOrDefaultAsync();
                if (dbCatName == null)
                {
                    await _context.Category.AddAsync(cat);
                    await _context.SaveChangesAsync();
                    return await _context.Category.FindAsync(cat.Id); // Auto ID from DB
                }
                else
                {
                    return cat;
                }
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        
        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                var dbCatId = await _context.Items.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
                if (dbCatId == null)
                {

                    var dbCat = await _context.Category.FindAsync(id);

                    if (dbCat == null)
                    {
                        return false;
                    }

                    _context.Category.Remove(dbCat);
                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Category> UpdateCategory(Category cat)
        {
            try
            {
                _context.Entry(cat).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return cat;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Category> GetCategory(int id)
        {
            try
            {
                return await _context.Category.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
