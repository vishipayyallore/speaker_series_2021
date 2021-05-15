namespace Books.API.Data
{

    public class SettingsData
    {
        public SettingsData(string sqlServerConnection) => SqlServerConnectionString = sqlServerConnection;

        public string SqlServerConnectionString { get; }
    }

}
