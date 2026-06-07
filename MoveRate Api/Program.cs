using Microsoft.EntityFrameworkCore;
using MoveRate_Api.DataContext; // Asıl DbContext sınıfınızın olduğu klasör

var builder = WebApplication.CreateBuilder(args);

// 1. SERVİS KAYITLARI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// BURAYI GÜNCELLEDİK: MoviesDbContext yerine ApplicationDbContext yazdık
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

// 2. UYGULAMANIN OLUŞTURULMASI
var app = builder.Build();

// 3. MIDDLEWARE / PIPELINE AYARLARI
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();