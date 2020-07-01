namespace Posts.Replies.Infrastructure.Configurations
{
    public interface IMongoConfiguration
    {
        string ConnectionString { get; set; }
    }
}