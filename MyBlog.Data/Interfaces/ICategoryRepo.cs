using MyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Interfaces
{
    public interface ICategoryRepo
    { 
        //Category CRUD     
        Task<List<Category>> GetCategoriesAsync();

        Task<Category?> GetCategoryAsync(int id);   

        Task<Category> SaveCategoryAsync(Category item);

        Task DeleteCategoryAsync(Category item);
    }
}
