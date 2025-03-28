using MoodSync.Components;
using MoodSync.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<MoodSyncContext>(options =>
    options.UseSqlite("Data Source=moodsync.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

app.UseStaticFiles();
app.UseRouting();

app.Use(async (context, next) =>
{
    await next.Invoke();
    if (context.Response.ContentType?.Contains("text/html") == true)
    {
        await context.Response.WriteAsync("<script src='https://cdn.jsdelivr.net/npm/chart.js@4.4.2/dist/chart.min.js'></script>");
        await context.Response.WriteAsync("<script src='/js/chartInterop.js'></script>");
    }
});

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();
