namespace BlogWebAPi.Controllers
{
    using Blog.Model;
    using BlogWebAPi.Attributes;
    using BlogWebAPi.Models.Tags;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using BlogWebAPi.Models.Posts;

    public class TagsController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage GetTags([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                           string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var dbContext = new BlogContext();
                using (dbContext)
                {
                    var user = dbContext.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid SessionKey");
                    }

                    var allTags = dbContext.Tags.OrderBy(t => t.Name).Select(TagModel.FromTag);

                    return this.Request.CreateResponse(HttpStatusCode.Created, allTags.ToList());
                }
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("getposts")]
        public HttpResponseMessage GetPostByTag([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                           string sessionKey,int tagId)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var dbContext = new BlogContext();
                using (dbContext)
                {
                    var user = dbContext.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid SessionKey");
                    }

                    var allPosts = dbContext.Posts.Include("User")
                                            .Include("Comment")
                                            .OrderByDescending(p=>p.Postdate)
                                            .Where(p => p.Tags.Any(t => t.Id == tagId))
                                            .Select(PostFullModel.FromPost);

                    return this.Request.CreateResponse(HttpStatusCode.Created, allPosts.ToList());
                }
            });

            return responseMsg;
        }
    }
}