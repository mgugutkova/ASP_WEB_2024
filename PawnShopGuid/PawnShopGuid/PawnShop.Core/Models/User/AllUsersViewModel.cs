namespace PawnShop.Core.Models.User
{
    public class AllUsersViewModel
    {
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsClient { get; set; } = true;

    }
}
