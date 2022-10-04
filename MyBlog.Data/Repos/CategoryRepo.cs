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
    public class CategoryRepo:ICategoryRepo
    {
        private IDbContextFactory<MyBlogDbContext> factory;

        public CategoryRepo(IDbContextFactory<MyBlogDbContext> factory)
        {
            this.factory = factory;
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

        public async Task<Category> SaveCategoryAsync(Category category)
        {
            using var context = factory.CreateDbContext();
            if (category.Id == 0) //Add new item
            {
                context.Categories.Add(category);
            }
            else //Update old item
            {
                context.Entry(category).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(Category item)
        {
            using var context = factory.CreateDbContext();
            context.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
