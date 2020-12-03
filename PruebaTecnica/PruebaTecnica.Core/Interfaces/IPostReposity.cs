

namespace PruebaTecnica.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PruebaTecnica.Core.Entities;

    public interface IPostReposity
    {
         Task<IEnumerable<Post>> GetPosts();
         Task<Post> GetPost(int id);
         Task InsertPost(Post post);
         Task<bool> UpdatePost(Post post);
         Task<bool> DeletePost(int id);
    }
}
