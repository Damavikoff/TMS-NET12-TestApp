using NET12_test.Domain;
using NET12_test.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// db
builder.Services.AddDbContext<ApplicationContext>();

// services
builder.Services.AddScoped<UserService>();

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

builder.Services.AddSpaStaticFiles(options =>
{
    options.RootPath = "wwwroot";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

// app.UseHttpsRedirection();
app.UseStaticFiles();
// app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin());
// app.UseRouting();

// app.UseAuthorization();

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "wwwroot";
});

app.MapControllers();

app.Run();
