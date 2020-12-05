namespace College.ApplicationCore.Common
{
    public static class Constants
    {

        public static class DataStore
        {
            public static string SqlConnectionString { get; set; } = "ConnectionStrings:CollegeDBConnectionString";

            public static string CosmosConnectionEndpoint { get; set; } = "CosmosDbConnectionStrings:accountEndPoint";
            public static string CosmosConnectionKey { get; set; } = "CosmosDbConnectionStrings:accountKey";
            public static string CosmosConnectionName { get; set; } = "CosmosDbConnectionStrings:databaseName";
        }

        public static class AddressConstants
        {
            public static string[] EnrollmentStatus = { "Pending", "In Progress", "Rejected", "Enrolled" };
        }

        public static class GenerateName
        {
            public static string[] Consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };

            public static string[] Vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        }

        public static class GenerateAddress
        {
            public static string FullAddress = "Flat Number: {0}, {1} Apartments, Street: {2}, Hyderabad.";
        }

    }

}
