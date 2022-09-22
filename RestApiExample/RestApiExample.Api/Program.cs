using RestApi.Example.NewsApi.Interfaces;
using RestApi.Example.NewsApi.Services;
using RestApiExample.Domain.Interfaces;
using RestApiExample.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services

builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<INewsApiClientInterface, NewsApiClient>();

#endregion

#region Options

builder.Services.Configure<ArticleOptions>(builder.Configuration.GetSection("ArticleOptions"));

#endregion

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
