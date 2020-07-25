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

    }

}
