using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;
using MyBlog.WASM.Client;

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
        [Route("BlogPostCount")]
        public async Task<int> GetBlogPostCountAsync()
        {
            return await _blogPostRepo.GetBlogPostCountAsync();
        }

        [HttpGet]
        [Route("BlogPosts")]
        public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts = 10, int startindex = 0)
        {
            return await _blogPostRepo.GetBlogPostsAsync(numberofposts, startindex);
        }

        [HttpGet]
        [Route("BlogPosts/{id}")]
        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            return await _blogPostRepo.GetBlogPostAsync(id);
        }

        [Authorize]
        [HttpPut]
        [Route("BlogPosts")]
        public async Task<BlogPost> SaveBlogPostAsync([FromBody] BlogPost item)
        {
            return await _blogPostRepo.SaveBlogPostAsync(item);
        }

        [Authorize]
        [HttpDelete]
        [Route("BlogPosts")]
        public async Task DeleteBlogPostAsync([FromBody] BlogPost item)
        {
            await _blogPostRepo.DeleteBlogPostAsync(item);
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _categoryRepo.GetCategoriesAsync();
        }

        [HttpGet]
        [Route("Categories/{id}")]
        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _categoryRepo.GetCategoryAsync(id);
        }

        [Authorize]
        [HttpPut]
        [Route("Categories")]
        public async Task<Category> SaveCategoryAsync([FromBody] Category item)
        {
            return await _categoryRepo.SaveCategoryAsync(item);
        }

        [Authorize]
        [HttpDelete]
        [Route("Categories")]
        public async Task DeleteCategoryAsync([FromBody] Category item)
        {
            await _categoryRepo.DeleteCategoryAsync(item);
        }

        [HttpGet]
        [Route("Tags")]
        public async Task<List<Tag>> GetTagsAsync()
        {
            return await _tagRepo.GetTagsAsync();
        }

        [HttpGet]
        [Route("Tags/{id}")]
        public async Task<Tag> GetTagAsync(int id)
        {
            return await _tagRepo.GetTagAsync(id);
        }

        [Authorize]
        [HttpPut]
        [Route("Tags")]
        public async Task<Tag> SaveTagAsync([FromBody] Tag item)
        {
            return await _tagRepo.SaveTagAsync(item);
        }

        [Authorize]
        [HttpDelete]
        [Route("Tags")]
        public async Task DeleteTagAsync([FromBody] Tag item)
        {
            await _tagRepo.DeleteTagAsync(item);
        }
    }
}
