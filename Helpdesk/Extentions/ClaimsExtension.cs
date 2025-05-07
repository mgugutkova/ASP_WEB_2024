using Helpdesk.Core.Enumeration;

namespace System.Security.Claims
{
    public static class ClaimsExtension
    {      
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(RoleNameItems.Admin.ToString());
        }

        public static bool IsUser(this ClaimsPrincipal user)
        {
            return user.IsInRole(RoleNameItems.User.ToString());
        }

        public static bool IsOperator(this ClaimsPrincipal user)
        {
            return user.IsInRole(RoleNameItems.Operator.ToString());
        }
    }
}
