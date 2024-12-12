using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using plants.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов в контейнер
builder.Services.AddControllersWithViews();

// Подключение к базе данных
builder.Services.AddDbContext<DBcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Настройка аутентификации с использованием куки
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";      // Путь к странице входа
        options.LogoutPath = "/Account/Logout";   // Путь к странице выхода
        options.ExpireTimeSpan = TimeSpan.FromHours(2); // Время жизни куки
    });

var app = builder.Build();

// Настройка middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Обработчик ошибок для продакшена
    app.UseHsts(); // Принудительное использование HTTPS
}

app.UseHttpsRedirection(); // Перенаправление HTTP на HTTPS
app.UseStaticFiles();      // Поддержка статических файлов

app.UseRouting();          // Настройка маршрутизации

app.UseAuthentication();   // Подключение аутентификации
app.UseAuthorization();    // Подключение авторизации

// Настройка маршрутов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();
