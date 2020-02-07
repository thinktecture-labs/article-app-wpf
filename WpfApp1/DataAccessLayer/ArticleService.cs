using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.DataAccessLayer
{
    public class ArticleService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUrl = new Uri("https://articleapi.azurewebsites.net/articles");

        public ArticleService(HttpClient httpClient) {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            var response = await httpClient.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Article>>(responseBody);
        }

        public async Task<IEnumerable<Article>> Search(string query = "")
        {
            var queryParams = new Dictionary<string, string> { { "q", query } };
            var url = QueryHelpers.AddQueryString(baseUrl.ToString(), queryParams);
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Article>>(responseBody);
        }

        public async Task<Article> Get(int id)
        {
            var response = await httpClient.GetAsync($"{baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Article>(responseBody);
        }
    }
}
