using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();
builder.Services.AddScoped<IInterviewServcie, InterviewService>();

//builder.Services.AddDbContext<InterviewsDbContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewsDbConnection"))
//    );

var dockerConnectionString = Environment.GetEnvironmentVariable("MSSQLConnectionStrings");
builder.Services.AddDbContext<InterviewsDbContext>(options => options.UseSqlServer(dockerConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
