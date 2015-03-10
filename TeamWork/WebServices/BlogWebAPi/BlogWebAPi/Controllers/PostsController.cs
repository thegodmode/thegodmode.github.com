namespace BlogWebAPi.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Net.Http;
    using System.Net;
    using System.Web.Http.ValueProviders;
    using BlogWebAPi.Attributes;
    using Blog.Model;
    using BlogWebAPi.Models.Posts;
    using System.Collections.Generic;
    using BlogWebAPi.Models.Comments;

    public class PostsController : BaseApiController
    {
        [HttpPost]
        public HttpResponseMessage PostCreatePost([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                                  string sessionKey, [FromBody]
                                                  PostFullModel postModel)
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
                    
                    postModel.AddTagsFromTitle();
                    postModel.PostDate = DateTime.Now;

                    List<Tag> tags = new List<Tag>();
                    foreach (var item in postModel.Tags)
                    {
                        var tagEntity = dbContext.Tags.Where(tag => tag.Name == item).FirstOrDefault();
                        if (tagEntity != null)
                        {
                            tags.Add(tagEntity);
                        }
                        else
                        {
                            var newTag = new Tag
                            {
                                Name = item
                            };

                            dbContext.Tags.Add(newTag);
                            dbContext.SaveChanges();
                            tags.Add(newTag);
                        }
                    }
                    var categories = dbContext.Tags.Where(tag => postModel.Tags.Contains(tag.Name)).ToList();

                    var postEntity = postModel.CreatePost(user.Id, categories);
                    dbContext.Posts.Add(postEntity);

                    dbContext.SaveChanges();

                    return this.Request.CreateResponse(HttpStatusCode.Created, new PostShortModel
                    {
                        Title = postEntity.Title,
                        Id = postEntity.Id
                    });
                }
            });

            return responseMsg;
        }

        [HttpGet]
        public HttpResponseMessage GetPosts([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
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

                    var allPosts = dbContext.Posts
                                            .Include("User")
                                            .Include("Comment")
                                            .OrderByDescending(p => p.Postdate)
                                            .Select(PostFullModel.FromPost);

                    return this.Request.CreateResponse(HttpStatusCode.Created, allPosts.ToList());
                }
            });

            return responseMsg;
        }

        [HttpGet]
        public HttpResponseMessage GetPage([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                           string sessionKey, int page, int count)
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

                    var allPosts = dbContext.Posts
                                            .Include("User")
                                            .Include("Comment")
                                            .OrderByDescending(p => p.Postdate)
                                            .Skip(page * count)
                                            .Take(count)
                                            .Select(PostFullModel.FromPost);

                    return this.Request.CreateResponse(HttpStatusCode.Created, allPosts.ToList());
                }
            });

            return responseMsg;
        }

        [HttpGet]
        public HttpResponseMessage GetPostsByTitle([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                                   string sessionKey, string keyword)
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

                    var allPosts = dbContext.Posts
                                            .Include("User")
                                            .Include("Comment")
                                            .OrderByDescending(p => p.Postdate)
                                            .Where(p => p.Title.ToLower().Contains(keyword.ToLower()))
                                            .Select(PostFullModel.FromPost);

                    return this.Request.CreateResponse(HttpStatusCode.Created, allPosts.ToList());
                }
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("tags")]
        public HttpResponseMessage GetPostsByTags([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                                  string sessionKey,
            string tags)
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
                    var splittedTags = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < splittedTags.Length; i++)
                    {
                        splittedTags[i] = splittedTags[i].ToLower().Trim();
                    }
                    var allPosts = dbContext.Posts
                                            .Include("User")
                                            .Include("Comment")
                                            .Include("Tag")
                                            .OrderByDescending(p => p.Postdate) //!t2.Except(t1).Any()
                                            .Where(y => splittedTags.All(sp=>y.Tags.Any(t=>t.Name==sp)))
                                                //y.Tags.All(t => splittedTags.Contains(t.Name)))
                                            .Select(PostFullModel.FromPost);

                    return this.Request.CreateResponse(HttpStatusCode.Created, allPosts.ToList());
                }
            });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("addComment")]
        public void PutCommentInPost([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                     string sessionKey,
            CommentShortModel comment, int postId)
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

                    var commentEntity = comment.CreateComment(user.Id, postId);
                    dbContext.Comments.Add(commentEntity);
                    dbContext.SaveChanges();

                    return this.Request.CreateResponse(HttpStatusCode.Created, commentEntity);
                }
            });
        }
    }
}