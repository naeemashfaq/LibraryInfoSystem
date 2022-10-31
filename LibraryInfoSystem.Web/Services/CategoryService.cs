using LibraryItems.Api.Entities;

namespace LibraryInfoSystem.Web.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly HttpClient _httpClient;
        public List<Category> Heroes { get; set; } = new List<Category>();

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Category> CreateCategory(Category cat)
        {


            var result = await _httpClient.PostAsJsonAsync($"api/Categories/CreateCategory", cat);
            var catg = await result.Content.ReadFromJsonAsync<Category>();
            return catg;

        }
        public async Task<List<Category>> GetCategories()
        {
            var abc =await _httpClient.GetFromJsonAsync<List<Category>>("api/Categories/GetCategories");
            return abc;
        }
        public async Task<Category> GetCategory(int id)
        {
            return await _httpClient.GetFromJsonAsync<Category>($"api/Categories/{id}");
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Categories/{id}");
            var status = await result.Content.ReadFromJsonAsync<bool>();
            return status;
        }

        public async Task UpdateCategory(Category cat, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Categories/{id}", cat);
            //Heroes = await result.Content.ReadFromJsonAsync<List<Category>>();
            //var aj = "g";
            //return Heroes;
        }
    }
}
