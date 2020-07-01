using System;

namespace Posts.Replies.Application.Dtos
{
    public class ReplyDto
    {
        public string Id { get; set; }

        public UserDto User { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}