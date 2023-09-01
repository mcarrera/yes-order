namespace be_photosi_api.Common
{
    public static class ErrorMessages
    {
        public const string DB_HOST = "Environment variable DB_HOST is missing";
        public const string DB_USER = "Environment variable DB_USER is missing";
        public const string DB_PASSWORD = "Environment variable DB_PASSWORD is missing";

        public const string MISSING_ADDRESS_ID = "Required parameter addressId is missing";

        public const string MISSING_PRODUCTS = "Required list of product is empty or null";
    }
}
