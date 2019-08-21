using Bll.Entity.Abstract;
using Bll.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticlesController : ControllerBase
    {
        public ILogger<ArticlesController> logger;
        private readonly IArticleRepository articleRepository;

        public ArticlesController(ILogger<ArticlesController> logger, IArticleRepository articleRepository)
        {
            this.logger = logger;
            this.articleRepository = articleRepository;
        }

        // GET: api/articles/list
        [HttpGet, Route("list")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticle()
        {
            return await articleRepository.GetAll().ToListAsync();
        }

        // GET: api/articles/search/key
        [HttpGet, Route("search/{key}")]
        public async Task<ActionResult<IEnumerable<Article>>> Search(string key)
        {
            return await articleRepository.FindBy(x => x.Title.Contains(key) || x.Content.Contains(key)).ToListAsync();
        }
        // GET: api/articles/5
        [HttpGet("{id}")]
        public ActionResult<Article> GetArticle(int id)
        {
            var article = articleRepository.GetSingle(x => x.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            return article;
        }

        // PUT: api/articles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }
            article.UpdateDate = DateTime.Now;
            articleRepository.Update(article);

            try
            {
                await articleRepository.CommitAsync();
                logger.LogInformation("Id:" + article.Id.ToString() + " makale güncellendi.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    logger.LogError(ex.Message);
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/articles
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            article.InsertDate = DateTime.Now;
            article.IsDeleted = false;
            await articleRepository.AddAsync(article);
            await articleRepository.CommitAsync();
            logger.LogInformation("Id:" + article.Id.ToString() + " makale kaydedildi.");

            return CreatedAtAction("GetArticle", new { id = article.Id }, article);
        }

        // DELETE: api/articles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> DeleteArticle(int id)
        {
            var article = articleRepository.GetSingle(x => x.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            article.IsDeleted = true;
            articleRepository.Update(article);
            await articleRepository.CommitAsync();
            logger.LogInformation("Id:" + article.Id.ToString() + " makale silindi.");
            return article;
        }

        private bool ArticleExists(int id)
        {
            return articleRepository.FindBy(e => e.Id == id).Any();
        }
    }
}
