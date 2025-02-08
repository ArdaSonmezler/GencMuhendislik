using gencmuhApi.Abstract;
using gencmuhApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gencmuhApi.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly AppDbContext _appDbContext;
        public BlogManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Blog t)
        {
            await _appDbContext.AddAsync(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Blog>> AllListAsync()
        {
            try
            {
                return await _appDbContext.Blogs.ToListAsync();
            }
            catch (System.Exception)
            {
                throw new Exception("Veritabanı hatası oluştu.");
            }
            
        }

        public async Task DeleteAsync(Blog t)
        {
            if(t is null)
                throw new KeyNotFoundException("Gönderilen değer boş olamaz.");
            _appDbContext.Remove(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            var blog = await _appDbContext.Blogs.FindAsync(id);
            if(blog is null)
                throw new KeyNotFoundException("Belirtilen ID'ye sahip kayıt bulunamadı.");

            return blog;
        }

        public async Task UpdateAsync(Blog t)
        {
            _appDbContext.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}