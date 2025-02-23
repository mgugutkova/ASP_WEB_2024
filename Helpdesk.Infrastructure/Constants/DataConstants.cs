namespace Helpdesk.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int DirectorateNameMaxLength =120;
        public const int DirectorateNameMinLength =3;

        public const int CategoryNameMaxLength = 100;
        public const int CategoryNameMinLength = 5;

        public const int RequestNameMaxLength = 20;
        public const int RequestNameMinLength = 3;

        public const int FirstNameMaxLength = 30;
        public const int FirstNameMinLength = 3;

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

        public const string ErrorMessageLength = "The field {0} must be between {1} and {2} characters";
    }
}
