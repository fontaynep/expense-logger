using ExpenseLogger.Data;          // for AppDbContext
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // for UseSqlite()
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=expenses.db"));
builder.Services.AddRazorPages(options =>
{
    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
});



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // <- Needed if you use wwwroot for CSS/JS

app.UseRouting();

app.UseAuthorization();

//app.MapStaticAssets();
//app.MapRazorPages()
//.WithStaticAssets();

app.MapRazorPages(); // map Razor Pages
app.MapGet("/", () => Results.Redirect("/Expenses"));

app.Run();
