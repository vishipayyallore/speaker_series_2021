namespace Books.API.Data
{

    public class SettingsData
    {
        public SettingsData(string sqlServerConnection) => SqlServerConnection = sqlServerConnection;

        public string SqlServerConnection { get; }
    }

}
