using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Posts.Replies.Application.Dtos;
using Posts.Replies.Application.Queries;
using Posts.Replies.Infrastructure.Services;

namespace Posts.Replies.Application.Handlers
{
    public class GetReplyByIdHandler : IRequestHandler<GetReplyByIdQuery, ReplyDto>
    {
        private readonly IMapper _mapper;

        private readonly IReplyService _replyService;

        public GetReplyByIdHandler(IMapper mapper, IReplyService replyService)
        {
            _mapper = mapper;

            _replyService = replyService;
        }

        public async Task<ReplyDto> Handle(GetReplyByIdQuery request, CancellationToken cancellationToken)
        {
            var reply = await _replyService.GetById(request.Id);

            var response = _mapper.Map<ReplyDto>(reply);

            return response;
        }
    }
}