using Bll.Entity.Abstract;
using Bll.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        ICommentRepository commentRepository;

        public CommentsController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        // GET: api/comments/list/1
        [HttpGet, Route("list/{articleId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetArticleComments(int articleId)
        {
            return await commentRepository.FindBy(x=>x.ArticleId == articleId).ToListAsync();
        }

        // GET: api/comments/5
        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = commentRepository.GetSingle(x => x.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        // PUT: api/comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }            
            commentRepository.Update(comment);

            try
            {
                await commentRepository.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/comments
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            comment.InsertDate = DateTime.Now;
            comment.IsDeleted = false;
            comment.CommentStatus = CommentStatus.WaitingforApproval;
            await commentRepository.AddAsync(comment);
            await commentRepository.CommitAsync();

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = commentRepository.GetSingle(x => x.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            comment.IsDeleted = true;
            commentRepository.Update(comment);
            await commentRepository.CommitAsync();

            return comment;
        }

        private bool CommentExists(int id)
        {
            return commentRepository.FindBy(e => e.Id == id).Any();
        }
    }
}