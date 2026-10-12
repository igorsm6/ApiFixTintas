using Microsoft.EntityFrameworkCore;
using PimTintas.API.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Adição de serviços...
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 1. PRIMEIRO cria o app aqui:
var app = builder.Build();

// --- O BLOCO DE SEED FICA AQUI (LOGO ABAIXO DE var app = builder.Build();) ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<PimTintas.API.Data.AppDbContext>();
        context.Database.EnsureCreated();

        // Se a tabela estiver vazia, insere os produtos com as novas propriedades de cor e tipo
        if (!context.Produtos.Any())
        {
            context.Produtos.AddRange(
                new PimTintas.API.Models.Produto
                {
                    Nome = "Tinta Acrílica Fosca Branco Neve 18L",
                    Descricao = "Tinta de alta cobertura para paredes internas e externas.",
                    Preco = 249.90m,
                    QuantidadeEstoque = 15,
                    Cor = "Branco Neve",
                    CorHex = "#FFFFFF",
                    TipoTinta = "Acrílica",
                    Volume = "18L"
                },
                new PimTintas.API.Models.Produto
                {
                    Nome = "Esmalte Sintético Azul Oceano 3.6L",
                    Descricao = "Indicado para superfícies de madeira e metal com acabamento brilhante.",
                    Preco = 89.90m,
                    QuantidadeEstoque = 30,
                    Cor = "Azul Oceano",
                    CorHex = "#0284C7",
                    TipoTinta = "Esmalte",
                    Volume = "3.6L"
                },
                new PimTintas.API.Models.Produto
                {
                    Nome = "Tinta Acrílica Areia do Deserto 18L",
                    Descricao = "Tom terroso moderno que traz aconchego para a sala e quartos.",
                    Preco = 269.90m,
                    QuantidadeEstoque = 12,
                    Cor = "Areia",
                    CorHex = "#D4B996",
                    TipoTinta = "Acrílica",
                    Volume = "18L"
                }
            );
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao popular o banco de dados.");
    }
}
// --------------------------------------------------------------------------

// Configuração do pipeline HTTP (Scalar / OpenApi)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "PIM Tintas API - Flutter";
        options.Theme = ScalarTheme.Mars;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();