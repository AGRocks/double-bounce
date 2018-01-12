using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using traininghub.mobile.models;

[assembly: Xamarin.Forms.Dependency(typeof(traininghub.mobile.Services.GamesService))]
namespace traininghub.mobile.Services
{
    public class GamesService : IDataStore<Game>
    {
        private readonly HttpClient http;
        private readonly string serviceUrl;

        public GamesService()
        {
            this.http = new HttpClient();
            http.MaxResponseContentBufferSize = 256000;

            this.serviceUrl = "http://traininghub-dev-api.azurewebsites.net/api/games";
        }

        public async Task<bool> AddItemAsync(Game game)
        {
            var uri = new Uri(string.Format(serviceUrl, string.Empty));
            var json = JsonConvert.SerializeObject(game);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await http.PostAsync(uri, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(Game game)
        {
            var uri = new Uri(string.Format(this.serviceUrl, game.Id));
            var result = await http.DeleteAsync(uri);
            return result.IsSuccessStatusCode;
        }

        public async Task<Game> GetItemAsync(string id)
        {
            var uri = new Uri(string.Format(this.serviceUrl + $"/byuser/{id}", string.Empty));
            var response = await http.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Game>(content);
            }

            return null;
        }

        public async Task<IEnumerable<Game>> GetItemsAsync(bool forceRefresh = false)
        {
            var uri = new Uri(string.Format(this.serviceUrl + $"/all", string.Empty));
            var response = await http.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Game>>(content);
            }

            return null;
        }

        public async Task<bool> UpdateItemAsync(Game item)
        {
            throw new System.NotImplementedException();
        }
    }
}
