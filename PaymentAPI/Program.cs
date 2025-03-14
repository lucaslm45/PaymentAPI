using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaymentAPI.Data;
using PaymentAPI.Business;
using PaymentAPI.Data.DIRepository;
using PaymentAPI.Data.Profiles;
using System.Reflection; // Adicionado para usar Assembly

var builder = WebApplication.CreateBuilder(args);

// Configura��o do DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Filename=Database.db")  // Configura o banco SQLite
);

// Configura��o do AutoMapper para mapear DTOs para entidades e vice-versa
builder.Services.AddAutoMapper(typeof(AccountProfile).Assembly);

// Configura��o do CORS para permitir todas as origens
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAllOrigins", builder => builder
        .AllowAnyOrigin()  // Permite qualquer origem
        .AllowAnyMethod()  // Permite qualquer m�todo HTTP (GET, POST, etc.)
        .AllowAnyHeader());  // Permite qualquer cabe�alho HTTP
});

// Configura��o dos controladores
builder.Services.AddControllers();

// Configura��o do Swagger (para documenta��o da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Payment API",
        Version = "v1"
    });
    // Se precisar incluir coment�rios XML no Swagger (�til para documenta��o de m�todos)
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.EnableAnnotations();  // Habilita o uso de anota��es no Swagger
});

// Registrar os Repositories e Services para inje��o de depend�ncia
DIBusiness.AddServices(builder.Services);  // Registra os servi�os da API
DIRepository.AddRepositories(builder.Services);  // Registra os reposit�rios

var app = builder.Build();

// Escopo para inicializar o banco de dados (cria o banco se ele n�o existir)
using (var scope = app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();  // Cria o banco de dados se n�o existir
}

// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment()) {
    // Ativa o Swagger apenas em ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  // Redireciona automaticamente para HTTPS

// Ativa o CORS com a pol�tica definida anteriormente
app.UseCors("AllowAllOrigins");

app.UseRouting();  // Ativa o roteamento de requisi��es

app.UseAuthorization();  // Habilita a autoriza��o de usu�rios

app.MapControllers();  // Mapeia os controladores para as rotas

app.Run();  // Inicia a aplica��o
