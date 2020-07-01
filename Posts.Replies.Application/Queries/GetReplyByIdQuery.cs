using MediatR;
using Posts.Replies.Application.Dtos;

namespace Posts.Replies.Application.Queries
{
    public class GetReplyByIdQuery : IRequest<ReplyDto>
    {
        public string Id { get; }

        public GetReplyByIdQuery(string id)
        {
            Id = id;
        }
    }
}