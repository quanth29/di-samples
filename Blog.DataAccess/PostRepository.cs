﻿using System.Collections.Generic;
using Blog.BusinessLogic;
using Blog.BusinessLogic.Models;
using Simple.Data;

namespace Blog.DataAccess
{
    public class PostRepository : IPostRepository
    {
        private readonly dynamic db = Database.OpenFile(@"Database\BlogDatabase2.sdf");

        public void Save(Post post)
        {
            db.Posts.Upsert(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return db.All();
        }

        public Post GetById(int id)
        {
            return db.Posts.FindById(id);
        }

        public void DeleteById(int postId)
        {
            db.Posts.DeleteById(postId);
        }
    }
}
