using Workforce.Tasks.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Controllers  
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddResolveDependency(builder.Configuration);

var app = builder.Build();

// Swagger somente em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Workforce Tasks API v1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();