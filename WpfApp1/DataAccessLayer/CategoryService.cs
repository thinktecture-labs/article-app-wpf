using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.DataAccessLayer
{
    public class CategoryService
    {
        private readonly HttpClient HttpClient;
        private readonly Uri BaseUrl = new Uri("https://articleapi.azurewebsites.net/categories");

        public CategoryService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await HttpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Category>>(responseBody);
        }

        public async Task<IEnumerable<Category>> GetSubcategories(string id)
        {
            var response = await HttpClient.GetAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Category>>(responseBody);
        }
    }
}
