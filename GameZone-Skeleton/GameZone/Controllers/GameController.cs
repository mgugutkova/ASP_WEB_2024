using GameZone.Data;
using GameZone.Models;
using GameZone.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

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

            string currentUser = GetUserId();

            //model.Genres = await GetGenres();
            await gameInterface.AddGameAsync(model, currentUser);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        private async Task<IEnumerable<GenresViewModel>> GetGenres()
        {
            var genres = await data.Genre
                .AsNoTracking()
                .Select(x => new GenresViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync();

            return genres;
        }

        [HttpGet]
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
