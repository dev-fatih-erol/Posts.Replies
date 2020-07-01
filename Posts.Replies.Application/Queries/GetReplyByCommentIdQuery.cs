using MediatR;
using Posts.Replies.Application.Dtos;

namespace Posts.Replies.Application.Queries
{
    public class GetReplyByCommentIdQuery : IRequest<PaginatedListDto<ReplyDto>>
    {
        public string CommentId { get; }

        public int PageIndex { get; }

        public GetReplyByCommentIdQuery(string commentId, int pageIndex)
        {
            CommentId = commentId;

            PageIndex = pageIndex < 1 ? 1 : pageIndex;
        }
    }
}