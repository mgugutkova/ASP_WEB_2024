namespace PawnShop.Infrastructure.Data
{
    public static class DataConstants
    {
        public const int GoodNameMaxLength = 50;
        public const int GoodNameMinLength = 3;

		public const int DescriptionMaxLength = 50;
		public const int DescriptonMinLength = 10;

		public const int FirstNameMaxLength = 20;
        public const int FirstNameMinLength = 3;

        public const int LastNameMaxLength = 20;
        public const int LastNameMinLength = 3;

        public const int PhoneNumberMaxLength = 10;
        public const int PhoneNumberMinLength = 4;

        public const int AddressMaxLength = 50;
        public const int AddressMinLength = 10;

        public const int StateNameMaxLength = 20;
        public const int StateNameMinLength = 3;

        public const string DataFormat = "dd/MM/yyyy";

        public const string ErrorMessageLength = "The field {0} must be between {1} and {2} characters";
    }
}
