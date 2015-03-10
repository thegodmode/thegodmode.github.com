using Blog.Model;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace BlogWebAPi.Models.Comments
{
    [DataContract]
    public class CommentShortModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        public Comment CreateComment(int userId, int postId)
        {
            return new Comment
            {
                Text = this.Text,
                PostDate = DateTime.Now,
                UserId = userId,
                PostId = postId
            };
        }
    }
}