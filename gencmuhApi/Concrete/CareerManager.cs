using gencmuhApi.Abstract;
using gencmuhApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gencmuhApi.Concrete
{
    public class CareerManager : ICareerService
    {
        private readonly AppDbContext _appDbContext;

        public CareerManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> AddAsync(Career t)
        {
            await _appDbContext.AddAsync(t);
            await _appDbContext.SaveChangesAsync();
            return null;
        }

        public async Task<List<Career>> AllListAsync()
        {
            try
            {
                return await _appDbContext.Careers.ToListAsync();
            }
            catch (System.Exception)
            {
                throw new Exception("Veritabanı hatası oluştu.");
            }
        }

        public async Task DeleteAsync(Career t)
        {
            if(t is null)
                throw new KeyNotFoundException("Gönderilen değer boş olamaz.");
            _appDbContext.Remove(t);
            await _appDbContext.SaveChangesAsync();
        }

        public Career GetById(int id)
        {
            var career = _appDbContext.Careers.Find(id);
            if(career is null)
                throw new KeyNotFoundException("Belirtilen ID'ye sahip kayıt bulunamadı.");

            return career;
        }

        public async Task UpdateAsync(Career t)
        {
            _appDbContext.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}