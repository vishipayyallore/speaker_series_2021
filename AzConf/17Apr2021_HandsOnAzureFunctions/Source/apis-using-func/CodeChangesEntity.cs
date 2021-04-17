using Microsoft.WindowsAzure.Storage.Table;

namespace AzGlobalIndia.Function
{
    public class CodeChangesEntity : TableEntity
    {
        public string FullName { get; set; }

        public string OwnerName { get; set; }

        public string RepoUrl { get; set; }

        public string AuthorName {get; set;}

        public string Added { get; set; }

        public string Removed { get; set; }

        public string Modified { get; set; }
    }

}
