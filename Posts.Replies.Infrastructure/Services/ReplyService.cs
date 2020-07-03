using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Posts.Replies.Infrastructure.Entities;

namespace Posts.Replies.Infrastructure.Services
{
    public class ReplyService : IReplyService
    {
        private readonly ReplyDbContext _dbContext;

        public ReplyService(ReplyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IMongoQueryable<Reply> GetByCommentId(string commentId)
        {
            return _dbContext.Replies.AsQueryable().Where(r => r.CommentId == commentId);
        }

        public async Task<Reply> GetById(string id, int userId)
        {
            return await _dbContext.Replies.Find(r => r.Id == id && r.User.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<Reply> GetById(string id)
        {
            return await _dbContext.Replies.Find(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task Delete(string id)
        {
            await _dbContext.Replies.DeleteOneAsync(r => r.Id == id);
        }

        public async Task Create(Reply reply)
        {
            await _dbContext.Replies.InsertOneAsync(reply);
        }
    }
}