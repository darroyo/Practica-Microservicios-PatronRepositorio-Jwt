using CorsCalled;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// todo CORS, al estar dentro de localhost funciona sin necesidad de cors
// solo se puede probar haciendo un ajax desde la consola del navegador
// el codigo blazor hace codigo de servidor por detrás y por eso lo permite siempre

// CORS solo es necesario para llamadas desde el front, desde el navegador, no desde el back
// CORS se configura en el receptor, no en el emisor

var corsSettings =
    builder.Configuration.GetSection("Cors").Get<CorsSettings>();

builder.Services.AddCors(x =>
{
//x.AddDefaultPolicy(y =>
//{
//    y.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//});
    x.AddPolicy("MiRestrictedPolicy",y=>{
        y.WithOrigins(corsSettings.AllowedOrigins)
        .WithMethods(corsSettings.AllowedVerbs)
        .WithHeaders(corsSettings.AllowedHeaders);

    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// todo CORS, al estar dentro de localhost funciona sin necesidad de cors
// solo se puede probar haciendo un ajax desde la consola del navegador
// el codigo blazor hace codigo de servidor por detrás y por eso lo permite siempre

// CORS solo es necesario para llamadas desde el front, desde el navegador, no desde el back
// CORS se configura en el receptor, no en el emisor
app.UseCors();
app.UseCors("MiRestrictedPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
