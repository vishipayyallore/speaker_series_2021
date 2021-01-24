namespace College.Core.Constants
{

    public static class Constants
    {

        public static class DataStore
        {
            public static string SqlConnectionString { get; } = "ConnectionStrings:CollegeDBConnectionString";

            public static string RedisConnectionString { get; } = "ConnectionStrings:CollegeRedisConnectionString";
        }

        public static class RedisCacheStore
        {
            public static string InstanceName { get; } = "CollegeRedisCache_";

            public static string AllProfessorsKey { get; } = "college_all_professors";

            public static string SingleProfessorsKey { get; } = "professor_";
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

        public static class AddressConstants
        {
            public static string[] EnrollmentTypes = { "Internal Exams", "Lab Session", "Library Usage", "External Exams" };

            public static string[] EnrollmentStatus = { "Pending", "In Progress", "Rejected", "Enrolled" };
        }
    }

}
