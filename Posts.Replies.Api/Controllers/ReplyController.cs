﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posts.Replies.Application.Commands;
using Posts.Replies.Application.Queries;

namespace Posts.Replies.Api.Controllers
{
    public class ReplyController : Controller
    {
        private readonly IMediator _mediator;

        public ReplyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Comment/{commentId:length(24)}/Reply")]
        public async Task<IActionResult> GetByCommentId([FromRoute]string commentId, [FromQuery]int pageIndex = 1)
        {
            return Ok(await _mediator.Send(new GetReplyByCommentIdQuery(commentId, pageIndex)));
        }

        [HttpGet]
        [Route("Reply/{id:length(24)}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            var reply = await _mediator.Send(new GetReplyByIdQuery(id));

            if (reply != null)
            {
                return Ok(reply);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Reply")]
        public async Task<IActionResult> Create([FromBody]CreateReplyCommand command)
        {
            var reply = await _mediator.Send(command);

            return Created($"Reply/{reply.Id}", reply);
        }
    }
}