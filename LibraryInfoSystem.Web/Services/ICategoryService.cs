using LibraryItems.Api.Entities;

namespace LibraryInfoSystem.Web.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category> CreateCategory(Category cat);
        Task<Category> GetCategory(int id);
        Task<bool> DeleteCategory(int id);
        Task UpdateCategory(Category cat, int id);
    }
}
