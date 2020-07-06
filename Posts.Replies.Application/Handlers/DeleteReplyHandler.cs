using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Posts.Replies.Application.Commands;
using Posts.Replies.Application.Exceptions;
using Posts.Replies.Infrastructure.Entities;
using Posts.Replies.Infrastructure.Services;

namespace Posts.Replies.Application.Handlers
{
    public class DeleteReplyHandler : IRequestHandler<DeleteReplyCommand, Unit>
    {
        private readonly IReplyService _replyService;

        public DeleteReplyHandler(IReplyService replyService)
        {
            _replyService = replyService;
        }

        public async Task<Unit> Handle(DeleteReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = await _replyService.Delete(request.Id, request.UserId);

            if (reply == null)
            {
                throw new NotFoundException(nameof(Reply));
            }

            return Unit.Value;
        }
    }
}