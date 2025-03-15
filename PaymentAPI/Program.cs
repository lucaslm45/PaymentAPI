using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaymentAPI.Data;
using PaymentAPI.Business;
using PaymentAPI.Data.Profiles;
using System.Reflection;
using PaymentAPI.Data.Repositories.DIRepository; // Added to use Assembly

var builder = WebApplication.CreateBuilder(args);

// Configuration of DbContext with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Filename=Database.db")  // Configures the SQLite database
);

// Configuration of AutoMapper to map DTOs to entities and vice versa
builder.Services.AddAutoMapper(typeof(AccountProfile).Assembly);

// Configuration of CORS to allow all origins
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAllOrigins", builder => builder
        .AllowAnyOrigin()  // Allows any origin
        .AllowAnyMethod()  // Allows any HTTP method (GET, POST, etc.)
        .AllowAnyHeader());  // Allows any HTTP header
});

// Configuration of controllers
builder.Services.AddControllers();

// Configuration of Swagger (for API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Payment API",
        Version = "v1"
    });
    // If you need to include XML comments in Swagger (useful for documenting methods)
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.EnableAnnotations();  // Enables the use of annotations in Swagger
});

// Register Repositories and Services for dependency injection
DIBusiness.AddServices(builder.Services);  // Registers the API services
DIRepository.AddRepositories(builder.Services);  // Registers the repositories

var app = builder.Build();

// Scope to initialize the database (creates the database if it doesn't exist)
using (var scope = app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();  // Creates the database if it doesn't exist
}

// HTTP pipeline configuration
if (app.Environment.IsDevelopment()) {
    // Enables Swagger only in the development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  // Automatically redirects to HTTPS

// Enables CORS with the previously defined policy
app.UseCors("AllowAllOrigins");

app.UseRouting();  // Enables request routing

app.UseAuthorization();  // Enables user authorization

app.MapControllers();  // Maps controllers to routes

app.Run();  // Starts the application
