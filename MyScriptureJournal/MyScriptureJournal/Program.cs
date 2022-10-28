using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;
//The following lines of code in this file create a
//WebApplicationBuilder with preconfigured defaults, add Razor
//Pages support to the Dependency Injection (DI) container, and
//build the app:
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//The RazorPagesMovieContext object handles the task of connecting to
//the database and mapping Movie objects to database records.
//The database context is registered with the Dependency Injection container
builder.Services.AddDbContext<MyScriptureJournalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyScriptureJournalContext") ?? throw new InvalidOperationException("Connection string 'MyScriptureJournalContext' not found.")));

//The following lines of code in this file create a
//WebApplicationBuilder with preconfigured defaults, add Razor
//Pages support to the Dependency Injection (DI) container, and
//build the app:
var app = builder.Build();

//Program.cs has been modified to do the following:
//Get a database context instance from the dependency injection (DI) container.
//Call the seedData.Initialize method, passing to it the database context instance.
//Dispose the context when the seed method completes. The using statement ensures the context is disposed.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

//The following code sets the exception endpoint to /Error and
//enables HTTP Strict Transport Security Protocol (HSTS) when the
//app is not running in development mode:
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Redirects HTTP requests to HTTPS.
app.UseHttpsRedirection();

//Enables static files, such as HTML, CSS, images, and JavaScript to be served.
app.UseStaticFiles();

//Adds route matching to the middleware pipeline.
app.UseRouting();

//Authorizes a user to access secure resources. This app doesn't use authorization, therefore this line could be removed.
//app.UseAuthorization();

//Configures endpoint routing for Razor Pages.
app.MapRazorPages();

//Runs the app.
app.Run();
