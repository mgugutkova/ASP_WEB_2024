using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GameZone.Data
{
    public static class DataConstants
    {
        public const int GameTitleMinLength = 2;
        public const int GameTitleMaxLength = 50;

        public const int GameDescriptionMinLength = 10;
        public const int GameDescriptionMaxLength = 500;

        public const int GenreNameMinLength = 3;
        public const int GenreNameMaxLength = 25;

        public const string ErroMessageLength = "The fiels {0} must be between {2} and {1}";

        public const string DateFormat = "yyyy-MM-dd";
    }
}
