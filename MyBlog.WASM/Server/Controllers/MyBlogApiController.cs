using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;

namespace MyBlog.WASM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyBlogApiController
    {
        private readonly IBlogPostRepo _blogPostRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly ITagRepo _tagRepo;

        public MyBlogApiController(IBlogPostRepo blogPostRepo,ICategoryRepo categoryRepo, ITagRepo tagRepo)
        {
            _blogPostRepo = blogPostRepo;
            _categoryRepo = categoryRepo;
            _tagRepo = tagRepo;
        }

        [HttpGet]
        [Route("BlogPosts")]
        public async Task<List<BlogPost>> GetBlogPostsAsync()
        {
            return await _blogPostRepo.GetBlogPostsAsync(10, 0);
        }
    }
}
