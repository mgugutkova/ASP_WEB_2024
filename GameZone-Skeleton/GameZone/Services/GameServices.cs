using GameZone.Data;
using GameZone.Models;
using GameZone.Services.Interfaces;

namespace GameZone.Services
{
    public class GameServices : IGameInterface
    {
        private readonly GameZoneDbContext data;
        public GameServices(GameZoneDbContext context)
        {
            data = context;
        }  

        public async Task AddGameAsync(GameFormViewModel model)
        {        
            var entity = new Game()
            {
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                ReleasedOn = DateTime.Parse(model.ReleasedOn),
                GenreId = model.GenreId
            };

            await data.AddAsync(entity);
            await data.SaveChangesAsync();
        }

      
    }
}
