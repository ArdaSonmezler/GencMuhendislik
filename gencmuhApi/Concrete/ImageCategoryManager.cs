using gencmuhApi.Abstract;
using gencmuhApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gencmuhApi.Concrete
{
    public class ImageCategoryManager : IImageCategoryService
    {
        private readonly AppDbContext _appDbContext;

        public ImageCategoryManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(ImageCategory t)
        {
            await _appDbContext.AddAsync(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<ImageCategory>> AllListAsync()
        {
            try
            {
                return await _appDbContext.ImageCategories.ToListAsync();
            }
            catch (System.Exception)
            {
                throw new Exception("Veritabanı hatası oluştu.");
            }
        }

        public async Task DeleteAsync(ImageCategory t)
        {
            if(t is null)
                throw new KeyNotFoundException("Gönderilen değer boş olamaz.");
            _appDbContext.Remove(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ImageCategory> GetByIdAsync(int id)
        {
            var imageCategory = await _appDbContext.ImageCategories.FindAsync(id);
            if(imageCategory is null)
                throw new KeyNotFoundException("Belirtilen ID'ye sahip kayıt bulunamadı.");

            return imageCategory;
        }

        public async Task UpdateAsync(ImageCategory t)
        {
            _appDbContext.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}