using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using plants.Data;

var builder = WebApplication.CreateBuilder(args);

// ���������� �������� � ���������
builder.Services.AddControllersWithViews();

// ����������� � ���� ������
builder.Services.AddDbContext<DBcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� �������������� � �������������� ����
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";      // ���� � �������� �����
        options.LogoutPath = "/Account/Logout";   // ���� � �������� ������
        options.ExpireTimeSpan = TimeSpan.FromHours(2); // ����� ����� ����
    });

var app = builder.Build();

// ��������� middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // ���������� ������ ��� ����������
    app.UseHsts(); // �������������� ������������� HTTPS
}

app.UseHttpsRedirection(); // ��������������� HTTP �� HTTPS
app.UseStaticFiles();      // ��������� ����������� ������

app.UseRouting();          // ��������� �������������

app.UseAuthentication();   // ����������� ��������������
app.UseAuthorization();    // ����������� �����������

// ��������� ���������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();
