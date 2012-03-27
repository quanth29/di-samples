using System;
using System.Web.Mvc;
using System.Web.Routing;
using Blog.BusinessLogic;
using Blog.BusinessLogic.Implementation;
using Blog.DataAccess;
using Composing_ASP.NET_MVC.Controllers;

namespace Composing_ASP.NET_MVC
{
    class MyControllerFactory : DefaultControllerFactory
    {
        private IPostRepository postRepository;
        private IPostService postService;

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            postRepository = new PostRepository();
            postService = new PostService(postRepository);

            if (controllerType == typeof(PostController))
            {
                return new PostController(postService);
            }
        }
    }
}