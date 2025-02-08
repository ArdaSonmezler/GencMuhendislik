using gencmuhApi.Abstract;
using gencmuhApi.Concrete;
using gencmuhApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<ICareerService, CareerManager>();
builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IImageCategoryService , ImageCategoryManager>();
builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<IYoutubeService, YoutubeManager>();


builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();  

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
