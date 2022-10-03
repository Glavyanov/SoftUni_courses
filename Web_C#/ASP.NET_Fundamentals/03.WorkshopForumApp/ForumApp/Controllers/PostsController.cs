namespace ForumApp.Controllers
{
    using ForumApp.Data;
    using ForumApp.Data.Entities;
    using ForumApp.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class PostsController : Controller
    {
        private readonly ForumDbContext context;

        public PostsController(ForumDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "All Posts";
            var posts = await this.context.Posts
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Select(x => new PostViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content
                }).ToListAsync();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Post post = new()
            {
                Title = model.Title,
                Content = model.Content
            };

            await this.context.Posts.AddAsync(post);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Post post = await this.context.Posts
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted)?? new Post();

            if (post.Title == null)
            {
                return BadRequest(); 
            }

            return View(new PostViewModel() 
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Post post = await this.context.Posts
                .FirstOrDefaultAsync(p => p.Id == model.Id && !p.IsDeleted)?? new Post();

            if (post.Title == null)
            {
                return BadRequest();
            }

            post.Title = model.Title;
            post.Content = model.Content;

            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Post post = await this.context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                return BadRequest();

            }

            post.IsDeleted = true;
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
