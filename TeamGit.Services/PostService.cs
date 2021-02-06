using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamGit.Data;
using TeamGit.Models;

namespace TeamGit.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate postCreate)
        {
            var entity = new Post()
            {
                Author = _userId,
                Title = postCreate.Title,
                Text = postCreate.Text
            };

        using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
       

        }
    }
}
