using GameZone.Data;
using GameZone.Models;
using GameZone.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GameZone.Services
{
    public class GameServices : IGameInterface
    {
        private readonly GameZoneDbContext data;
        public GameServices(GameZoneDbContext context)
        {
            data = context;
        }  

        public async Task AddGameAsync(GameFormViewModel model, string currentUser)
        {        
            var entity = new Game()
            {
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                ReleasedOn = DateTime.Parse(model.ReleasedOn),
                GenreId = model.GenreId,
                PublisherId = currentUser
            };

            await data.AddAsync(entity);
            await data.SaveChangesAsync();
        }


    }
}
