using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Posts.Replies.Infrastructure.Entities;

namespace Posts.Replies.Infrastructure.Services
{
    public interface IReplyService
    {
        IMongoQueryable<Reply> GetByCommentId(string commentId);

        Task<Reply> GetById(string id);

        Task Create(Reply reply);
    }
}