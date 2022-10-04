using MyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Interfaces
{
    public interface IMyBlogApi
    {
        //Blog Post CRUD
        Task<BlogPost?> GetBlogPostAsync(int id);

        Task<int> GetBlogPostCountAsync(); 
        
        Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex);
      
        Task<BlogPost> SaveBlogPostAsync(BlogPost item);

        Task DeleteBlogPostAsync(BlogPost item);

        //Category CRUD
        Task<Category?> GetCategoryAsync(int id);        

        Task<List<Category>> GetCategoriesAsync();

        Task<Category> SaveCategoryAsync(Category item);

        Task DeleteCategoryAsync(Category item);

        //Tag CRUD
        Task<Tag?> GetTagAsync(int id);
        Task<List<Tag>> GetTagsAsync();        


        Task<Tag> SaveTagAsync(Tag item);
  
        Task DeleteTagAsync(Tag item);

    }
}
