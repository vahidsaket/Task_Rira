using Microsoft.OpenApi.Models;
using Task_Rira;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddJwt(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    //options.SwaggerEndpoint("/openapi/v1.json", "v1");
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.MapGet("/", () => "you can test with /openapi/v1.json");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
