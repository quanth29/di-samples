﻿using System;
using System.Web.Mvc;
using Blog.BusinessLogic;
using Composing_ASP.NET_MVC.Models;
using PostEntity=Blog.BusinessLogic.Models.Post;

namespace Composing_ASP.NET_MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            if (postService == null)
            {
                throw new ArgumentNullException("postService");
            }

            this.postService = postService;
        }

        //
        // GET: /Post/

        public ActionResult Index()
        {
            var posts = postService.GetPosts();
            return View(posts);
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id)
        {
            var post = postService.GetPostById(id);
            return View(post);
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(Post postViewModel)
        {
            try
            {
                // This can be achieved more simply and consistently across an application using AutoMapper
                var post = new PostEntity
                               {
                                   Title = postViewModel.Title,
                                   Summary = postViewModel.Summary,
                                   Body = postViewModel.Body,
                                   PublicationDate = postViewModel.PublicationDate
                               };
                postService.PublishPost(post);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Post/Edit/5
 
        public ActionResult Edit(int id)
        {
            var post = postService.GetPostById(id);
            return View(post);
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Post/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Post/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
