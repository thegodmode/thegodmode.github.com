using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BlogWebAPi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
              name: "PostsByTagApi",
              routeTemplate: "api/tags/{tagId}/posts",
              defaults: new
              {
                  controller = "tags",
                  action = "getposts"
              });

            config.Routes.MapHttpRoute(
              name: "CommentPostApi",
              routeTemplate: "api/posts/{postId}/comment",
              defaults: new
              {
                  controller = "posts",
                  action = "addComment"
              });


            config.Routes.MapHttpRoute(
               name: "PosttApi",
               routeTemplate: "api/posts/{page}/{tags}",
               defaults: new
               {
                   controller = "posts",
                   action = "tags"
               });

            config.Routes.MapHttpRoute(
                name: "UsertApi",
                routeTemplate: "api/users/{action}",
                defaults: new
                {
                    controller = "users"
                });
            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           
            config.EnableQuerySupport();
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
