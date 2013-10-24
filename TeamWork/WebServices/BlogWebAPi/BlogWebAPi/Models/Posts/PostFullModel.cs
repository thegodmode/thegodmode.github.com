using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace BlogWebAPi.Models.Posts
{
    [DataContract]
    public class PostFullModel
    {
        public static Expression<Func<Post, PostFullModel>> FromPost
        {
            get
            {
                return x => new PostFullModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    PostBy = x.User.Displayname,
                    PostDate = x.Postdate,
                    Text = x.Text,
                    Tags = x.Tags.Select(y => y.Name),
                    Comments = x.Comments.Select(c => new CommentsFullModel
                    {
                        Text = c.Text,
                        PostDate = c.PostDate,
                        CommentBy = c.User.Displayname
                    })
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "postBy")]
        public string PostBy { get; set; }

        [DataMember(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public IEnumerable<CommentsFullModel> Comments { get; set; }

        public Post CreatePost(int userId, ICollection<Tag> tags)
        {
            return new Post
            {
                Title = this.Title,
                Text = this.Text,
                UserId = userId,
                Postdate = PostDate,
                Tags = tags
            };
        }

        public void AddTagsFromTitle()
        {
            var titletags = this.Title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> listOfTags = new List<string>();
            listOfTags.AddRange(this.Tags);

            for (int i = 0; i < titletags.Length; i++)
            {
                titletags[i] = titletags[i].ToLower().Trim();
                if (!listOfTags.Contains(titletags[i]))
                {
                    listOfTags.Add(titletags[i]);
                }
            }

            this.Tags = listOfTags;
        }

       
    }
}