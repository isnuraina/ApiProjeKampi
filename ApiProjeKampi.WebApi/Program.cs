using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
