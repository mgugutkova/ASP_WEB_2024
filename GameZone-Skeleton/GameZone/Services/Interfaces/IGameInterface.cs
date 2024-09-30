using GameZone.Models;

namespace GameZone.Services.Interfaces
{
    public interface IGameInterface
    {
        public Task AddGameAsync(GameFormViewModel model);
    }
}
