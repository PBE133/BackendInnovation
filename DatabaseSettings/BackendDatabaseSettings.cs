namespace BackendInnovation.DatabaseSettings
{
    public class BackendDatabaseSettings : IBackendDatabaseSettings
    {
        public string IdeaCollectionName { get; set; }
        public string ConnectionStrings { get ; set; }
        public string DatabaseName { get; set; }
    }
}
