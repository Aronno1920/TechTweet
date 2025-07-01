using Microsoft.EntityFrameworkCore;
using TechTweetAPI.Data;
using TechTweetAPI.Repositories.Implementations;
using TechTweetAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

/*--------SETUP SERVICES--------*/
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(Program));

/*--------SETUP DEPENDENCY--------*/
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

/*--------SETUP CORS--------*/
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

/*--------BUILD SERVICES--------*/
var app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TechTweetAPI v1");
    });
//}

/*--------RUN APPLICATION--------*/
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();