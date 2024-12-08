using static PawnShop.Core.Constants.AdminConstants;

namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }

        public static bool IsUser(this ClaimsPrincipal user)
        {
            return user.IsInRole(UserRole);
        }
    }
}
