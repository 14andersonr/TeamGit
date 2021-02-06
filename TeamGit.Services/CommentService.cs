using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamGit.Data;
using TeamGit.Models;

namespace TeamGit.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {

            _userId = userId;
        }

        public IEnumerable<CommentItem> GetComments()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new CommentItem
                                {
                                    Text = e.Text,
                                    Id = e.Id,
                                }
                        );

                return query.ToArray();

            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == id && e.Author == _userId);
                return
                    new CommentDetail
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                    };
            }
        }
        public bool CreateComment(Comment model)
        {
            var entity =
                new Comment()
                {
                    Text = model.Text,
                    Id = model.Id,
                    PostId = model.PostId,
                    Author = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
