using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRazorWebMvc.Services
{
    public interface ISongsService
    {
        Task<IEnumerable<Song>> GetAllSongs();
        Task<Song> GetSongById(int id);
        void AddSong(Song song);
        void UpdateSong(int id, Song song);
        void DeleteSong(int id);
    }
}
