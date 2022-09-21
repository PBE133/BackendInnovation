namespace BackendInnovation.DatabaseSettings
{
    public interface IBackendDatabaseSettings
    {
        string IdeaCollectionName { get; set; }
        string ConnectionStrings { get; set; }
        string DatabaseName { get; set; }
    }
}
