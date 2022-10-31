using LibraryItems.Api.Entities;

namespace LibraryItems.Api.Repositries
{
    public interface ILibraryItemRepository
    {
        Task<IEnumerable<LibraryItem>> GetItems();
        public Task<LibraryItem> AddLibItem(LibraryItem item);
        public Task<LibraryItem> UpdateLibItem(LibraryItem item);
        public Task<(bool, string)> DeleteLibItem(int id);
        public Task<LibraryItem> GetLibItem(int id);
    }
}
