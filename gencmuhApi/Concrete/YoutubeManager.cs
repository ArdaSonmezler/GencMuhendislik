using gencmuhApi.Abstract;
using gencmuhApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gencmuhApi.Concrete
{
    public class YoutubeManager : IYoutubeService
    {
        private readonly AppDbContext _appDbContext;

        public YoutubeManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Youtube t)
        {
            await _appDbContext.AddAsync(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Youtube>> AllListAsync()
        {
            try
            {
                return await _appDbContext.Youtubes.ToListAsync();
            }
            catch (System.Exception)
            {
                throw new Exception("Veritabanı hatası oluştu.");
            }
        }

        public async Task DeleteAsync(Youtube t)
        {
            if(t is null)
                throw new KeyNotFoundException("Gönderilen değer boş olamaz.");
            _appDbContext.Remove(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Youtube> GetByIdAsync(int id)
        {
            var youtube = await _appDbContext.Youtubes.FindAsync(id);
            if(youtube is null)
                throw new KeyNotFoundException("Belirtilen ID'ye sahip kayıt bulunamadı.");

            return youtube;
        }

        public async Task UpdateAsync(Youtube t)
        {
            _appDbContext.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}