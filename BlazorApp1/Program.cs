using BlazorApp1.Data;
using BlazorApp1.Components;
using Microsoft.AspNetCore.Builder;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Добавляем DbContext
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddControllers();//регистрация контроллера

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()    // разрешаем все источники (на время разработки)
            .AllowAnyMethod()    // разрешаем GET, POST, PUT и т.д.
            .AllowAnyHeader();   // разрешаем любые заголовки
    });
});

var app = builder.Build();  //  DI container

// Применяем миграции автоматически
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Swagger UI по адресу /swagger
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapControllers(); //включает обработку маршрутов, заданных в контроллерах
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();