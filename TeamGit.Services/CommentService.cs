using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamGit.Data;

namespace TeamGit.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {

            _userId = userId;
        }

        public IEnumerable<Comment> GetComments()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.Auther == _userId)
                        .Select(
                            e =>
                                new Comment
                                {
                                    Text = e.Text,
                                    Id = e.Id,
                                }
                        );

                return query.ToArray();

            }
        }

        public bool CreateComment(Comment model)
        {
            var entity =
                new Comment()
                {
                    Text = model.Text,
                    Id = model.Id,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
