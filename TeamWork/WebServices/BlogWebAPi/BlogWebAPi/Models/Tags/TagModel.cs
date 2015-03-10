using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace BlogWebAPi.Models.Tags
{
    [DataContract]
    public class TagModel
    {
        public static Expression<Func<Tag, TagModel>> FromTag
        {
            get
            {
                return t => new TagModel
                {

                    Id = t.Id,
                    Name = t.Name,
                    PostNumber = t.Posts.Count
                };
            }
        }

        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="posts")]
        public int PostNumber { get; set; }
    }
}