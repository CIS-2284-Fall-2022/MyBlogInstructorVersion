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
        IDbContextFactory<MyBlogDbContext> factory;

        public MyBlogAPIServerSide(IDbContextFactory<MyBlogDbContext> factory)
        {
            this.factory = factory; 
        }

        public Task DeleteBlogPostAsync(BlogPost item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTagAsync(Tag item)
        {
            throw new NotImplementedException();
        }

        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            using var context = factory.CreateDbContext();

            //cmd_str = "SELECT * FROM tblBlogPosts WHERE Id = @Id;"
            //cmd = new Sqlcommand(conn, cmd_str);
            //cmd.parameters.addwithvalue("Id",id)

            return await context.BlogPosts.Include(p=>p.Category).Include(p=>p.Tags).FirstOrDefaultAsync(p => p.Id == id); //<- LINQ
        }

        public Task<int> GetBlogPostCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetTagAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag>> GetTagsAsync()
        {
            throw new NotImplementedException();
        }

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
