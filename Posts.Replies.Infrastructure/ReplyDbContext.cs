using MongoDB.Driver;
using Posts.Replies.Infrastructure.Configurations;
using Posts.Replies.Infrastructure.Entities;

namespace Posts.Replies.Infrastructure
{
    public class ReplyDbContext
    {
        private readonly IMongoDatabase _database;

        public ReplyDbContext(IMongoConfiguration configuration)
        {
            var client = new MongoClient(configuration.ConnectionString);

            _database = client.GetDatabase(MongoUrl.Create(configuration.ConnectionString).DatabaseName);
        }

        public IMongoCollection<Reply> Replies => _database.GetCollection<Reply>(nameof(Reply));
    }
}