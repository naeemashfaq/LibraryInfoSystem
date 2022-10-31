using LibraryItems.Api.Entities;

namespace LibraryInfoSystem.Web.Services
{
    public class LibraryItemService : ILibraryItemService
    {
        private readonly HttpClient _httpClient;

        public LibraryItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<LibraryItem>> GetLibraryItems()
        {

            var abc = await _httpClient.GetFromJsonAsync<List<LibraryItem>>("api/LibraryItems/GetLibraryItems");
            return abc;
        }

        public async Task CreateLibraryItem(LibraryItem item)
        {
             var result = await _httpClient.PostAsJsonAsync($"api/LibraryItems/CreateLibraryItem", item);
            //var retItem = await result.Content.ReadFromJsonAsync<LibraryItem>();
            //return retItem;
        }

        public async Task<LibraryItem> GetLibraryItem(int id)
        {
            return await _httpClient.GetFromJsonAsync<LibraryItem>($"api/LibraryItems/{id}");
        }

        public async Task DeleteLibraryItem(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/LibraryItems/{id}");
        }

        public async Task UpdateLibraryItem(LibraryItem item, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/LibraryItems/{id}", item);
        }
    }
}
