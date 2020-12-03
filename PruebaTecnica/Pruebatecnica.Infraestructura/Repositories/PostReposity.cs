

namespace Pruebatecnica.Infraestructura.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Pruebatecnica.Infrastructura.Data;
    using PruebaTecnica.Core.Entities;
    using PruebaTecnica.Core.Interfaces;


    public class PostReposity : IPostReposity
    {

        private readonly DatabaseContext _dbContext;

        public PostReposity(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _dbContext.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            return post;
        }

        public async Task InsertPost(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<bool> UpdatePost(Post post)
        {
            var currentPost = await GetPost(post.PostId);

            currentPost.Description = post.Description;
            currentPost.Image = post.Image;
            
            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }

        public async Task<bool> DeletePost(int id)
        {
            var currentPost = await GetPost(id);
            _dbContext.Posts.Remove(currentPost);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }






    }
}
