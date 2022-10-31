using LibraryItems.Api.Entities;

namespace LibraryItems.Api.Repositries
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetItems();
        Task<Category> AddCategory(Category cat);
        public Task<Category> UpdateCategory(Category cat);
        public Task<bool> DeleteCategory(int id);
        public Task<Category> GetCategory(int id);
    }
}
