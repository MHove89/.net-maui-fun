using Blog.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Umbraco.Cms.Core;
using Umbraco.Cms.Web.Common.Controllers;

namespace Website.Umbraco.Controllers
{
    public class BlogApiController : UmbracoApiController
    {
        private readonly IPublishedContentQuery _contentQuery;

        public BlogApiController(IPublishedContentQuery contentQuery)
        {
            _contentQuery = contentQuery;
        }

        [HttpGet]
        public BlogPostsResponse GetBlogPosts()
        {
            var blogPosts = _contentQuery.ContentAtRoot().DescendantsOrSelfOfType("blog").FirstOrDefault()?.Children();
            var listOfBlogPosts = new List<BlogPost>();

            if (blogPosts != null)
            {
                var options = new JsonSerializerOptions()
                {
                    MaxDepth = 10000,
                    IgnoreNullValues = true,
                    IgnoreReadOnlyProperties = false
                };

                foreach (var blogPost in blogPosts)
                {
                    var typedBlogPost = new BlogPost
                    {
                        Id = blogPost.Id,
                        Header = blogPost.Value<string>("header"),
                        FeatureText = blogPost.Value<string>("featureText"),

                    };

                    listOfBlogPosts.Add(typedBlogPost);
                }
            }

            return new BlogPostsResponse()
            {
                BlogPosts = listOfBlogPosts,
                Total = listOfBlogPosts.Count
            };
        }

    }
}
