using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaymentAPI.Data;
using PaymentAPI.Business;
using PaymentAPI.Data.DIRepository;
using PaymentAPI.Data.Profiles;
using System.Reflection; // Adicionado para usar Assembly

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Filename=Database.db")  // Configura o banco SQLite
);

// Configuração do AutoMapper para mapear DTOs para entidades e vice-versa
builder.Services.AddAutoMapper(typeof(AccountProfile).Assembly);

// Configuração do CORS para permitir todas as origens
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAllOrigins", builder => builder
        .AllowAnyOrigin()  // Permite qualquer origem
        .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc.)
        .AllowAnyHeader());  // Permite qualquer cabeçalho HTTP
});

// Configuração dos controladores
builder.Services.AddControllers();

// Configuração do Swagger (para documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Payment API",
        Version = "v1"
    });
    // Se precisar incluir comentários XML no Swagger (útil para documentação de métodos)
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.EnableAnnotations();  // Habilita o uso de anotações no Swagger
});

// Registrar os Repositories e Services para injeção de dependência
DIBusiness.AddServices(builder.Services);  // Registra os serviços da API
DIRepository.AddRepositories(builder.Services);  // Registra os repositórios

var app = builder.Build();

// Escopo para inicializar o banco de dados (cria o banco se ele não existir)
using (var scope = app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();  // Cria o banco de dados se não existir
}

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment()) {
    // Ativa o Swagger apenas em ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  // Redireciona automaticamente para HTTPS

// Ativa o CORS com a política definida anteriormente
app.UseCors("AllowAllOrigins");

app.UseRouting();  // Ativa o roteamento de requisições

app.UseAuthorization();  // Habilita a autorização de usuários

app.MapControllers();  // Mapeia os controladores para as rotas

app.Run();  // Inicia a aplicação
