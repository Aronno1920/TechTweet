var builder = WebApplication.CreateBuilder(args);

/*--------SETUP SERVICES--------*/
builder.Services.AddControllers();
builder.Services.AddOpenApi();

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