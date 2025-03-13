using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EBANX.Data;
using System.Text.Json.Serialization;
using EBANX.Business;
using EBANX.Data.DIRepository;
using EBANX.Data.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework com SQLite em memória
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Filename=:memory:")
);

builder.Services.AddAutoMapper(typeof(AccountProfile).Assembly);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        // Remove ReferenceHandler.Preserve
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

//builder.Services.AddControllers()
//    .AddJsonOptions(options => {
//        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Ebanx Project API",
        Version = "v1"
    });
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);
    c.EnableAnnotations();
});

// Registrar Repositories e Services
DIBusiness.AddServices(builder.Services);
DIRepository.AddRepositories(builder.Services);

var app = builder.Build();

// Criar escopo para inicializar o banco
using (var scope = app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.OpenConnection(); // Necessário para SQLite em memória
    context.Database.EnsureCreated();  // Criar tabelas temporárias
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Ativar o CORS
app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
