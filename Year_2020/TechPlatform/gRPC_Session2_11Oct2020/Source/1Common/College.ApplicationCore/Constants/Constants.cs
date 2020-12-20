namespace College.ApplicationCore.Constants
{

    public static class Constants
    {

        public static class SQLDataStore
        {
            public static string ConnectionString { get; set; } = "ConnectionStrings:CollegeDBConnectionString";
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
