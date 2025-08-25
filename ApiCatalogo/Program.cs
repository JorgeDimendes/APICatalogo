using CatalogoProduto.Core.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using CatalogoProduto.Assinc;
using CatalogoProduto.Assinc.DTOs.Mappgings;
using CatalogoProduto.Assinc.Repositories;
using CatalogoProduto.Assinc.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles).AddNewtonsoftJson();

// Depois apagar:
builder.Services.AddControllers()
    .AddApplicationPart(typeof(ProdutosController).Assembly);
builder.Services.AddControllers()
    .AddApplicationPart(typeof(CategoriasController).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Usando Strig de Conex�o
#region Banco de Dados
builder.Services.AddDbContext<AppDbContext>(
    context => context.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
#endregion

//Repository
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Jwt
#region Autenticação Jwt
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();
#endregion

//Token
#region MyRegion
builder.Services.AddIdentity<IdentityUser, IdentityRole>().
    AddEntityFrameworkStores<AppDbContext>().
    AddDefaultTokenProviders();
#endregion

//Automapper
builder.Services.AddAutoMapper(typeof(ProdutoDtoMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();