using ASRazorWebMvc.Services;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRazorWebMvc.Controllers
{
    public class AlbumController : Controller
    {

        private IAlbumsService _albumsService;
        public AlbumController(IAlbumsService albumsService)
        {
            _albumsService = albumsService;
        }

        // GET: AlbumController
        public async Task<ActionResult> IndexShowAllAlbums()
        {
            IEnumerable<Album> albums = await _albumsService.GetAllAlbums();
            return View(albums.ToList());
        }

        public ActionResult IndexGetAlbumById()
        {
            Album alb = new Album(0, " ", " ");
            return View(alb);
        }

        public ActionResult IndexAddAlbum()
        {
            Album alb = new Album(0, " ", " ");
            return View(alb);
        }

        public ActionResult IndexDeleteAlbum()
        {
            Album alb = new Album(0, " ", " ");
            return View(alb);
        }

        public ActionResult IndexFindForUpdateAlbum()
        {
            Album alb = new Album(0, " ", " ");
            return View(alb);
        }
        public async Task<ActionResult> IndexUpdateAlbum(Album alb)
        {
            var album = await _albumsService.GetAlbumById(alb.AlbumId);
            return View(album);
        }

        [HttpPost]
        public async Task<IActionResult> GetAlbumById(Album alb)
        {
            var album = await _albumsService.GetAlbumById(alb.AlbumId);
            return View(album);
        }

        [HttpPost]
        public IActionResult Delete(Album alb)
        {
            _albumsService.DeleteAlbum(alb.AlbumId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddAlbum(Album alb)
        {
            _albumsService.AddAlbum(alb);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult UpdateAlbum(Album alb)
        {
            _albumsService.UpdateAlbum(alb.AlbumId, alb);
            return RedirectToAction("Index", "Home");
        }
    }
}
