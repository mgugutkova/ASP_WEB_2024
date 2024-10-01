using GameZone.Models;

namespace GameZone.Services.Interfaces
{
    public interface IGameInterface
    {
        Task AddGameAsync(GameFormViewModel model, string currentUser);
    }
}
