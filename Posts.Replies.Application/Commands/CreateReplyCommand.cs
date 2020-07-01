using MediatR;
using Posts.Replies.Application.Dtos;
using Posts.Replies.Application.Extensions;

namespace Posts.Replies.Application.Commands
{
    public class CreateReplyCommand : IRequest<ReplyDto>
    {
        public UserDto User { get; }

        public string Text { get; }

        public string CommentId { get; }

        public CreateReplyCommand(UserDto user, string text, string commentId)
        {
            User = user;

            Text = text.Clear();

            CommentId = commentId;
        }
    }
}