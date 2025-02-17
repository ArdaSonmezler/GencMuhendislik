using System.Data;
using gencmuhApi.Abstract;
using gencmuhApi.ExceptionHandler;
using gencmuhApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace gencmuhApi.Concrete
{
    public class YoutubeManager : IYoutubeService
    {
        private readonly AppDbContext _appDbContext;

        public YoutubeManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> AddAsync(Youtube t)
        {
            try
            {
                var linkTitle = new SqlParameter("@LinkTitle", t.LinkTitle);
                var url = new SqlParameter("@Url", t.Url);

                var idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                await _appDbContext.Database.ExecuteSqlRawAsync("EXEC sp_AddYoutube @LinkTitle, @Url, @Id OUTPUT",
                linkTitle,url,idParam);

                return idParam.Value.ToString(); 
            }
            catch (System.Exception ex)
            {
                
                throw new Exception("Youtube kaydı eklenirken hata meydana geldi!");
            }
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

        public Youtube GetById(int id)
        {
            try
            {
                var idParam = new SqlParameter("@Id",id);
                var youtubeVideo = _appDbContext.Youtubes
                .FromSqlRaw("EXEC sp_GetYoutubeById @Id",idParam)
                .AsEnumerable().FirstOrDefault();

                if(youtubeVideo == null)
                {
                    throw new NotFoundException($"ID {id} ile kayıtlı youtube videosu bulunamadı");
                }
                    
                return youtubeVideo;
            }
            catch(Exception){
                throw;
            }
        }

        public async Task UpdateAsync(Youtube t)
        {
            _appDbContext.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}