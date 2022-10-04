using MyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Interfaces
{
    public interface ITagRepo
    {
        //Tag CRUD
        Task<List<Tag>> GetTagsAsync();

        Task<Tag?> GetTagAsync(int id);

        Task<Tag> SaveTagAsync(Tag item);
  
        Task DeleteTagAsync(Tag item);
    }
}
