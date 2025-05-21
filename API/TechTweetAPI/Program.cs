using Microsoft.EntityFrameworkCore;
using TechTweetAPI.Data;

var builder = WebApplication.CreateBuilder(args);

/*--------SETUP SERVICES--------*/
builder.Services.AddControllers();
builder.Services.AddOpenApi();

/*--------SETUP DEPENDENCY--------*/
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

/*--------BUILD SERVICES--------*/
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TechTweetAPI v1");
    });
}

/*--------RUN APPLICATION--------*/
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();