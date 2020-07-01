using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver.Linq;
using Posts.Replies.Application.Dtos;
using Posts.Replies.Application.Helpers;
using Posts.Replies.Application.Queries;
using Posts.Replies.Infrastructure.Entities;
using Posts.Replies.Infrastructure.Services;

namespace Posts.Replies.Application.Handlers
{
    public class GetReplyByCommentIdHandler : IRequestHandler<GetReplyByCommentIdQuery, PaginatedListDto<ReplyDto>>
    {
        private readonly IMapper _mapper;

        private readonly IReplyService _replyService;

        public GetReplyByCommentIdHandler(IMapper mapper, IReplyService replyService)
        {
            _mapper = mapper;

            _replyService = replyService;
        }

        public async Task<PaginatedListDto<ReplyDto>> Handle(GetReplyByCommentIdQuery request, CancellationToken cancellationToken)
        {
            var query = _replyService.GetByCommentId(request.CommentId);
            var replies = from r in query
                          orderby r.CreatedDate
                          select r;

            var pageSize = 5;
            var paginatedReplies = await PaginatedList<Reply>.CreateAsync(replies, request.PageIndex, pageSize);

            var response = _mapper.Map<PaginatedListDto<ReplyDto>>(paginatedReplies);

            return response;
        }
    }
}