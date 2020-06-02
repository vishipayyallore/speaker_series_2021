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

    }

}
