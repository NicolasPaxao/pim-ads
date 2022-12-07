using Swashbuckle.Swagger;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using web_api.Data;
using web_api.Repository.Apolice;
using web_api.Repository.Assistencia;
using web_api.Repository.Automovel;
using web_api.Repository.Cliente;
using web_api.Repository.Cobertura;
using web_api.Repository.Funcionarios;
using web_api.Repository.Planos;
using web_api.Repository.Relatorios;
using web_api.Repository.RetornaCliente;
using web_api.Repository.Seguradora;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IDbConnection>(
op => { 
    return new SqlConnection(builder.Configuration.GetConnectionString("conexao"));
});
builder.Services.AddScoped<IDaoCliente, DaoCliente>();
builder.Services.AddScoped<IDaoFuncionario, DaoFuncionario>();
builder.Services.AddScoped<IDaoAutomovel, DaoAutomovel>();
builder.Services.AddScoped<IDaoSeguradora, DaoSeguradora>();
builder.Services.AddScoped<IDaoPlano, DaoPlano>();
builder.Services.AddScoped<IDaoCobertura, DaoCobertura>();
builder.Services.AddScoped<IDaoAssistencia, DaoAssistencia>();
builder.Services.AddScoped<IDaoApolice, DaoApolice>();
builder.Services.AddScoped<IDaoRetornaCliente, DaoRetornaCliente>();
builder.Services.AddScoped<IDaoRelatorio, DaoRelatorio>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    opt =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        opt.IncludeXmlComments(xmlPath);
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
