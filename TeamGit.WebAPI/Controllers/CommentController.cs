using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamGit.Data;
using TeamGit.Models;
using TeamGit.Services;

namespace TeamGit.WebAPI.Controllers
{
    public class CommentController : ApiController
    {
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);
        }

        public IHttpActionResult Post(Comment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();
            if (!service.CreateComment(comment))
                return InternalServerError();
            return Ok();
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }

        public IHttpActionResult Get(int id)
        {
            CommentService noteService = CreateCommentService();
            var note = noteService.GetCommentById(id);
            return Ok(note);
        }
    }

}

