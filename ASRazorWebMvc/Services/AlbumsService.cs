using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASRazorWebMvc.Services
{
    public class AlbumsService : IAlbumsService
    {
        private HttpClient HttpClient { get; }

        public AlbumsService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        public async void AddAlbum(Album song)
        {
            var url = "https://localhost:44353/api/albums";
            using var response = await this.HttpClient.PostAsJsonAsync(url, song);
        }

        public async void DeleteAlbum(int id)
        {
            string res = id.ToString();
            var url = "https://localhost:44353/api/albums/" + res;
            using var response = await this.HttpClient.DeleteAsync(url);
        }

        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            var url = "https://localhost:44353/api/albums";
            using var response = await this.HttpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            List<Album> albums = JsonSerializer.Deserialize<List<Album>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return albums;
        }

        public async Task<Album> GetAlbumById(int id)
        {
            string res = id.ToString();
            var url = "https://localhost:44353/api/albums/" + res;
            using var response = await this.HttpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var album = JsonSerializer.Deserialize<Album>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return album;
        }

        public async void UpdateAlbum(int id, Album song)
        {
            string res = id.ToString();
            var url = "https://localhost:44353/api/albums/" + res;
            using var response = await this.HttpClient.PutAsJsonAsync(url, song);
        }
    }
}
