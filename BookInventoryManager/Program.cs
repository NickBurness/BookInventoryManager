using Microsoft.EntityFrameworkCore;
using BookInventoryManager.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using BookInventoryManager.Models;
using BookInventoryManager.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddFluentValidation();

// fluent validation rules
ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Continue;
ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

// fluent validators
builder.Services.AddTransient<IValidator<Book>, BookValidator>();
builder.Services.AddTransient<IValidator<Author>, AuthorValidator>();
builder.Services.AddTransient<IValidator<Category>, CategoryValidator>();

builder.Services.AddDbContext<BookManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookManagerContext") ?? throw new InvalidOperationException("Connection string 'BookManagerContext' not found.")));

//Add the database exception filter
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BookManagerContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();


app.Run();
