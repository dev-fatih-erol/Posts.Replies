using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Posts.Replies.Application.Commands;
using Posts.Replies.Application.Dtos;
using Posts.Replies.Infrastructure.Entities;
using Posts.Replies.Infrastructure.Services;

namespace Posts.Replies.Application.Handlers
{
    public class CreateReplyHandler : IRequestHandler<CreateReplyCommand, ReplyDto>
    {
        private readonly IMapper _mapper;

        private readonly IReplyService _replyService;

        public CreateReplyHandler(IMapper mapper, IReplyService replyService)
        {
            _mapper = mapper;

            _replyService = replyService;
        }

        public async Task<ReplyDto> Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = new Reply();
            var user = _mapper.Map<User>(request.User);
            reply.User = user;
            reply.Text = request.Text;
            reply.CreatedDate = DateTime.UtcNow;
            reply.CommentId = request.CommentId;

            await _replyService.Create(reply);

            var response = _mapper.Map<ReplyDto>(reply);

            return response;
        }
    }
}