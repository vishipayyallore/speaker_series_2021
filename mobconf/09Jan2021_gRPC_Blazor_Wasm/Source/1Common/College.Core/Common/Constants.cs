namespace College.Core.Common
{

    public static class Constants
    {

        public static class DataStore
        {
            public static string SqlConnectionString { get; } = "ConnectionStrings:CollegeDBConnectionString";
        }

        public static class Weather
        {

            public static string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild",
                "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

        }

    }

}
