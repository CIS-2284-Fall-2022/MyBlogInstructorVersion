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
        
        //Retrieve
        Task<int> GetBlogPostCountAsync();               

        Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex);

        Task<List<Category>> GetCategoriesAsync();

        Task<List<Tag>> GetTagsAsync();

        Task<BlogPost> GetBlogPostAsync(int id);

        Task<Category> GetCategoryAsync(int id);

        Task<Tag> GetTagAsync(int id);

        //Create

        Task<BlogPost> SaveBlogPostAsync(BlogPost item);

        Task<Category> SaveCategoryAsync(Category item);

        Task<Tag> SaveTagAsync(Tag item);

        //Delete

        Task DeleteBlogPostAsync(BlogPost item);

        Task DeleteCategoryAsync(Category item);

        Task DeleteTagAsync(Tag item);

        //No update!!

    }
}
