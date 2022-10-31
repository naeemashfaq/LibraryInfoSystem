using LibraryItems.Api.Entities;

namespace LibraryInfoSystem.Web.Services
{
    public interface ILibraryItemService
    {
        Task<List<LibraryItem>> GetLibraryItems();
        Task CreateLibraryItem(LibraryItem item);
        Task<LibraryItem> GetLibraryItem(int id);
        Task DeleteLibraryItem(int id);
        Task UpdateLibraryItem(LibraryItem item, int id);
    }
}

