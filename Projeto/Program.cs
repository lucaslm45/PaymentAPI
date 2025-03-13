using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Projeto.Data;
using System.Text.Json.Serialization;
using Projeto.Business;
using Projeto.Data.DIRepository;
using Projeto.Data.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Filename=Projeto.db")
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
        Title = "Project API",
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
    context.Database.EnsureCreated(); // Apenas isso já cria o banco no arquivo
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
