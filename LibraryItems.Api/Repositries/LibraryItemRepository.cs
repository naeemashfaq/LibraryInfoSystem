using Microsoft.EntityFrameworkCore;
using LibraryItems.Api.Data;
using LibraryItems.Api.Entities;

namespace LibraryItems.Api.Repositries
{
    public class LibraryItemRepository : ILibraryItemRepository
    {
        private readonly LibraryDbContext _context;

        public LibraryItemRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LibraryItem>> GetItems()
        {
           // var LibItems = await _context.Items.ToListAsync();
            //var LibItems = await _context.Items.Include(d => d.Category).ToListAsync();
            var LibItems = await _context.Items.Include(d => d.Category).OrderBy(x =>x.Category.CategoryName).ToListAsync();

            return LibItems;

        }

        public async Task<LibraryItem> AddLibItem(LibraryItem item)
        {
            try
            {
                await _context.Items.AddAsync(item);
                await _context.SaveChangesAsync();
                return await _context.Items.FindAsync(item.Id);
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<(bool, string)> DeleteLibItem(int id)
        {
            try
            {
                var dbItem = await _context.Items.FindAsync(id); 

                if (dbItem == null)
                {
                    return (false, "Library Item could not be found");
                }

                _context.Items.Remove(dbItem);
                await _context.SaveChangesAsync();

                return (true, "Category got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        public async Task<LibraryItem> UpdateLibItem(LibraryItem item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<LibraryItem> GetLibItem(int id)
        {
            try
            {
                return await _context.Items.FindAsync(id); 
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
