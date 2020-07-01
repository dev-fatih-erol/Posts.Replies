using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Posts.Replies.Infrastructure.Entities
{
    public class Reply
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public User User { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CommentId { get; set; }
    }
}