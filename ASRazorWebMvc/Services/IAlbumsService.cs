using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace ASRazorWebMvc.Services
{
    public interface IAlbumsService
    {
        Task<IEnumerable<Album>> GetAllAlbums();
        Task<Album> GetAlbumById(int id);
        void AddAlbum(Album song);
        void UpdateAlbum(int id, Album song);
        void DeleteAlbum(int id);
    }
}
