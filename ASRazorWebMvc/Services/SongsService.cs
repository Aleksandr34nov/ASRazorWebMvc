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
    public class SongsService : ISongsService
    {
        private HttpClient HttpClient { get; }

        public SongsService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        public async void AddSong(Song song)
        {
            var url = "https://localhost:44353/api/songs";
            using var response = await this.HttpClient.PostAsJsonAsync(url, song);
        }

        public async void DeleteSong(int id)
        {
            string res = id.ToString();
            var url = "https://localhost:44353/api/songs/" + res;
            using var response = await this.HttpClient.DeleteAsync(url);
        }

        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            var url = "https://localhost:44353/api/songs";
            using var response =  await this.HttpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var songs = JsonSerializer.Deserialize<List<Song>>(content, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true});
            return songs;
        }

        public async Task<Song> GetSongById(int id)
        {
            string res = id.ToString();
            var url = "https://localhost:44353/api/songs/" + res;
            using var response = await this.HttpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var song = JsonSerializer.Deserialize<Song>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return song;
        }

        public async void UpdateSong(int id, Song song)
        {
            var url = "https://localhost:44353/api/songs/" + id;
            using var response = await this.HttpClient.PutAsJsonAsync(url, song);
        }
    }
}
