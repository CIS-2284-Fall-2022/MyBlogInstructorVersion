using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;
using System.Reflection.Metadata;

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
                //Fix references to tags
                var ids = post.Tags.Select(t => t.Id);
                post.Tags = context.Tags.Where(t => ids.Contains(t.Id)).ToList();
                //Fix reference to blog post
                post.Category = await context.Categories.FirstOrDefaultAsync(c => c.Id == post.Category.Id);
                context.BlogPosts.Add(post);
            }
            else //Update old item
            {
                //Fix references to tags
                var ids = post.Tags.Select(t => t.Id);
                post.Tags = context.Tags.Where(t => ids.Contains(t.Id)).ToList();
                //Fix reference to blog post
                post.Category = await context.Categories.FirstOrDefaultAsync(c => c.Id == post.Category.Id);
                context.Entry(post).State = EntityState.Modified;
            }
              //  Code from text book:
            //var currentpost = await context.BlogPosts.Include(p => p.Category).Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == post.Id);
            //    currentpost.PublishDate = post.PublishDate;
            //    currentpost.Title = post.Title;
            //    currentpost.Text = post.Text;
            //    var ids = post.Tags.Select(t => t.Id);
            //    currentpost.Tags = context.Tags.Where(t => ids.Contains(t.Id)).ToList();
            //    currentpost.Category = await context.Categories.FirstOrDefaultAsync(c => c.Id == post.Category.Id);
            //}
            await context.SaveChangesAsync();
            return post;
        }



    }
}
