var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Simple endpoints
// `GET /` - Returns a greeting message
app.MapGet("/", () => "Hello from .NET in Docker!")
    .WithName("GetGreeting")
    .WithOpenApi();

// `GET /api/health` - Health check endpoint
app.MapGet("/api/health", () => new { status = "healthy", timestamp = DateTime.UtcNow })
    .WithName("HealthCheck")
    .WithOpenApi();

// `GET /api/info` - Information endpoint
app.MapGet("/api/info", () => new { 
    application = "DotnetApp",
    version = "1.0.0",
    runtime = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription
})
.WithName("GetInfo")
.WithOpenApi();

app.Run();
