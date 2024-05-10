using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Infrastructure.Data;
using KnowledgeBasev2.Infrastructure.ContractImplementations;
using Microsoft.EntityFrameworkCore;
using KnowledgeBasev2.Infrastructure.Handler.CommandHandler;
using KnowledgeBasev2.Application.Queries;
using KnowledgeBasev2.Application.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RemoteDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IKbCommand, KBCommandRepo>();
builder.Services.AddScoped<IKbCode, KBCodeRepo>();
builder.Services.AddScoped<IKbDocumentation, KBDocumentationRepo>();
builder.Services.AddScoped<KBCommandRepo>();

builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssemblies(typeof(GetCommandListQueryHandler).Assembly, typeof(GetCommandsListQuery).Assembly);
    //config.RegisterServicesFromAssembly(typeof(GetCommandsListQuery).Assembly);
    config.RegisterServicesFromAssemblies(typeof(CreateNewCmdCommandHandler).Assembly, typeof(CreateNewCmdCommand).Assembly);
    });

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
