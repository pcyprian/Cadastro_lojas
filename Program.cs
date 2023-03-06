using cadastro_lojas_fullstack.Infra;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));


var connString = new ConfigurationBuilder().AddJsonFile("appsettings.Localhost.json").Build()
            .GetSection("StringDeConexao:Padrao");

builder.Services.AddDbContext<CadastroLojasContext>(options => options.UseSqlServer(connString.Value));
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "MyPolicy",
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        }
        );
    }

    );

var app = builder.Build();

/*if (app.Environment.EnvironmentName == "Localhost" || app.Environment.IsDevelopment())
{    app.UseSwagger();
   app.UseSwaggerUI();}*/

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

