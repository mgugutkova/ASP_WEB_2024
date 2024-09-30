using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using GameZone.Services;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using GameZone.Services.Interfaces;

namespace GameZone.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameInterface gameInterface;
        private readonly GameZoneDbContext data;
        public GameController(GameZoneDbContext option, IGameInterface _gameInterface)
        {
            data = option;
            gameInterface = _gameInterface;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameFormViewModel();

            model.Genres = await GetGenres();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameFormViewModel model)
        {

            DateTime releaseDate = DateTime.Now;

            if (!DateTime.TryParseExact(
               model.ReleasedOn,
               DataConstants.DateFormat,
               CultureInfo.InvariantCulture,
               DateTimeStyles.None,
               out releaseDate))
            {
                ModelState
                    .AddModelError(nameof(model.ReleasedOn), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await gameInterface.AddGameAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ICollection<Genres>> GetGenres()
        {
            var genres = await data.Genre
                .AsNoTracking()
                .Select(x => new Genres()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync();

            return genres;
        }
    }
}
