using Autofac;
using Autofac.Extensions.DependencyInjection;
using Grpc.Server.Middleware;
using Grpc.Server.Services;
using TaskRira.Application;
using TaskRira.DataAccess;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccess(builder.Configuration).AddApplication(builder.Environment);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.AddServices());

builder.Services.AddAutoMapper(typeof(Program).Assembly);


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserCallService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapGrpcReflectionService().AllowAnonymous();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
