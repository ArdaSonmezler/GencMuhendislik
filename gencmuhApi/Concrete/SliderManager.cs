using gencmuhApi.Abstract;
using gencmuhApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gencmuhApi.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly AppDbContext _appDbContext;

        public SliderManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Slider t)
        {
            await _appDbContext.AddAsync(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Slider>> AllListAsync()
        {
            try
            {
                return await _appDbContext.Sliders.ToListAsync();
            }
            catch (System.Exception)
            {
                throw new Exception("Veritabanı hatası oluştu.");
            }
        }

        public async Task DeleteAsync(Slider t)
        {
            if(t is null)
                throw new KeyNotFoundException("Gönderilen değer boş olamaz.");
            _appDbContext.Remove(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Slider> GetByIdAsync(int id)
        {
            var slider = await _appDbContext.Sliders.FindAsync(id);
            if(slider is null)
                throw new KeyNotFoundException("Belirtilen ID'ye sahip kayıt bulunamadı.");

            return slider;
        }

        public async Task UpdateAsync(Slider t)
        {
            _appDbContext.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}