using MediatR;

namespace Posts.Replies.Application.Commands
{
    public class DeleteReplyCommand : IRequest<Unit>
    {
        public string Id { get; }

        public int UserId { get; }

        public DeleteReplyCommand(string id, int userId)
        {
            Id = id;

            UserId = userId;
        }
    }
}