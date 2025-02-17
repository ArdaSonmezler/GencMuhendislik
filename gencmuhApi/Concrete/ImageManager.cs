using gencmuhApi.Abstract;
using gencmuhApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gencmuhApi.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly AppDbContext _appDbContext;

        public ImageManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> AddAsync(Image t)
        {
            await _appDbContext.AddAsync(t);
            await _appDbContext.SaveChangesAsync();
            return null;
        }

        public async Task<List<Image>> AllListAsync()
        {
            try
            {
                return await _appDbContext.Images.ToListAsync();
            }
            catch (System.Exception)
            {
                throw new Exception("Veritabanı hatası oluştu.");
            }
        }

        public async Task DeleteAsync(Image t)
        {
            if(t is null)
                throw new KeyNotFoundException("Gönderilen değer boş olamaz.");
            _appDbContext.Remove(t);
            await _appDbContext.SaveChangesAsync();
        }

        public Image GetById(int id)
        {
            var image = _appDbContext.Images.Find(id);
            if(image is null)
                throw new KeyNotFoundException("Belirtilen ID'ye sahip kayıt bulunamadı.");

            return image;
        }

        public async Task UpdateAsync(Image t)
        {
            _appDbContext.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}