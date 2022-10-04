using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Repos
{
    public class BlogPostRepo : IBlogPostRepo
    {
        private IDbContextFactory<MyBlogDbContext> factory;

        public BlogPostRepo(IDbContextFactory<MyBlogDbContext> factory)
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
            return await context.BlogPosts.OrderByDescending(p => p.PublishDate).Skip(startindex).Take(numberofposts).ToListAsync();
        }

        public async Task DeleteBlogPostAsync(BlogPost item)
        {
            using var context = factory.CreateDbContext();
            context.BlogPosts.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task<BlogPost> SaveBlogPostAsync(BlogPost post)
        {
            using var context = factory.CreateDbContext();
            if (post.Id == 0) //Add new item
            {
                context.BlogPosts.Add(post);
            }
            else //Update old item
            {
                context.Entry(post).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return post;
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

        public async Task<Tag> SaveTagAsync(Tag tag)
        {
            using var context = factory.CreateDbContext();
            if (tag.Id == 0) //Add new item
            {
                context.Tags.Add(tag);
            }
            else //Update old item
            {
                context.Entry(tag).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return tag;
        }
    }
}
