using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;

namespace MyBlog.Data.Repos
{
    public class TagRepo:ITagRepo
    {
        private IDbContextFactory<MyBlogDbContext> factory;

        public TagRepo(IDbContextFactory<MyBlogDbContext> factory)
        {
            this.factory = factory;
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
