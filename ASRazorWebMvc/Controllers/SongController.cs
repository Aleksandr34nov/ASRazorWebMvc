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
    public class SongController : Controller
    {
        private ISongsService _songsService;
        public SongController(ISongsService songsService)
        {
            _songsService = songsService;
        }

        // GET: SongController async Task<IActionResult>
        public async Task<IActionResult> IndexShowAllSongs()
        {
            IEnumerable<Song> songs = await _songsService.GetAllSongs();
            return View(songs.ToList());
        }

        public ActionResult IndexGetSongById()
        {
            Song sng = new Song(0, " ", 0, null);
            return View(sng);
        }

        public ActionResult IndexAddSong()
        {
            Song sng = new Song(0, " ", 0, null);
            return View(sng);
        }

        public ActionResult IndexDeleteSong()
        {
            Song sng = new Song(0, " ", 0, null);
            return View(sng);
        }

        public ActionResult IndexFindForUpdateSong()
        {
            Song sng = new Song(0, " ", 0, null);
            return View(sng);
        }

        public async Task<ActionResult> IndexUpdateSong(Song sng)
        {
            var song = await _songsService.GetSongById(sng.SongId);
            return View(song);
        }

        [HttpPost]
        public IActionResult AddSong(Song sng)
        {
            _songsService.AddSong(sng);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> GetSongById(Song sng)
        {
            var song = await _songsService.GetSongById(sng.SongId);
            return View(song);
        }

        [HttpPost]
        public IActionResult Delete(Song sng)
        {
            _songsService.DeleteSong(sng.SongId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult UpdateSong(Song sng)
        {
            _songsService.UpdateSong(sng.SongId, sng);
            return RedirectToAction("Index", "Home");
        }
    }
}
