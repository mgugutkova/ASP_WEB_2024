namespace PawnShop.Core.Interfaces
{
    public interface IApplicationUserService
    {
        Task<string> UserFullName(string userId);
    }
}
