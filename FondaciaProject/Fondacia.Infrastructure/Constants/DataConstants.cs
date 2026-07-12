namespace Fondacia.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int EmailMaxLength =100;
        public const int EmailMinLength =10;

        public const int PasswordMaxLength = 50;
        public const int PasswordMinLength = 6;

        public const int FullNameMaxLength = 100;
        public const int FullNameMinLength = 3;

        public const int ShortNameMaxLength = 20;
        public const int ShortNameMinLength = 3;

        // Ограничение за снимка: максимум 2 MB
       // public const int maxFileSize = 2 * 1024 * 1024; // 2 MB
        //
        public const int LastNameMaxLength = 50;
        public const int LastNameMinLength = 3;

        public const int AddressMaxLength = 80;
        public const int AddressMinLength = 3;

        public const int PhoneNumberMaxLength = 20;
        public const int PhoneNumberMinLength = 6;

        public const int PositionMaxLength = 50;
        public const int PositionMinLength = 5;

        public const int DescriptionMaxLength = 100;
        public const int DescriptionMinLength = 5;

        public const int CommentMaxLength = 50;
        public const int CommentMinLength = 5;

        public const string DataFormat = "dd/MM/yyyy";

        public const string ErrorMessageLength = "The field {0} must be between {2} and {1} characters";

        public const int ItemsPerPage = 5;
    }
}
