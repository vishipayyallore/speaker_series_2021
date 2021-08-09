namespace BooksStore.Core.Common
{

    public static class Constants
    {

        public static class DataStore
        {
            public static string SqlConnectionString { get; } = "ConnectionStrings:SqlServerConnection";

            public static string RedisConnectionString { get; } = "ConnectionStrings:RedisConnectionString";
        }

        public static class RedisCacheStore
        {
            public static string AllBooksKey { get; } = "all_books";

            public static string SingleBookKey { get; } = "book_";
        }

    }

}
