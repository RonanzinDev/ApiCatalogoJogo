using ApiCatalogoJogos.Repositories;
using ApiCatalogoJogos.Services;

var builder = WebApplication.CreateBuilder(args);
var Services = builder.Services;
// Add services to the container.
Services.AddScoped<IJogoService, JogoService>();
Services.AddScoped<IJogoRepository, JogoRepository>();
Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
