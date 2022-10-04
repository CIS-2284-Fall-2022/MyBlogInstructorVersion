using MyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Interfaces
{
    public interface IBlogPostRepo
    {
        //Blog Post CRUD
        Task<int> GetBlogPostCountAsync();

        Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex);

        Task<BlogPost?> GetBlogPostAsync(int id);        
      
        Task<BlogPost> SaveBlogPostAsync(BlogPost item);

        Task DeleteBlogPostAsync(BlogPost item);   
    }
}
