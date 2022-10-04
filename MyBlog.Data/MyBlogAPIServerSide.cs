using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data
{
    public class MyBlogAPIServerSide : IMyBlogApi
    {
        private IDbContextFactory<MyBlogDbContext> factory;

        public MyBlogAPIServerSide(IDbContextFactory<MyBlogDbContext> factory)
        {
            this.factory = factory; 
        }

        //BlogPost CRUD
        public async Task<BlogPost?> GetBlogPostAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.BlogPosts.Include(p => p.Category).Include(p => p.Tags).Where(p => p.Id == id).FirstOrDefaultAsync(); //<- LINQ
        }

        public async Task<int> GetBlogPostCountAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.BlogPosts.CountAsync();
        }

        public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            using var context = factory.CreateDbContext();
            return await context.BlogPosts.OrderByDescending(p=>p.PublishDate).Skip(startindex).Take(numberofposts).ToListAsync();  
        }

        public async Task DeleteBlogPostAsync(BlogPost item)
        {
            using var context = factory.CreateDbContext();
            context.BlogPosts.Remove(item);
            await context.SaveChangesAsync();
        }

        //Categories CRUD
        public async Task<List<Category>> GetCategoriesAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteCategoryAsync(Category item)
        {
            using var context = factory.CreateDbContext();
            context.Remove(item);
            await context.SaveChangesAsync();
        }

        //Tags CRUD
        public Task<Tag?> GetTagAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return context.Tags.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Tag>> GetTagsAsync()
        {
            using var context = factory.CreateDbContext();
                return context.Tags.ToListAsync();
        }

        public async Task DeleteTagAsync(Tag item)
        {
            using var context = factory.CreateDbContext();
            context.Remove(item);
            await context.SaveChangesAsync();
        }
        //-------------------------



        public Task<BlogPost> SaveBlogPostAsync(BlogPost item)
        {
            throw new NotImplementedException();
        }

        public Task<Category> SaveCategoryAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> SaveTagAsync(Tag item)
        {
            throw new NotImplementedException();
        }
    }
}
