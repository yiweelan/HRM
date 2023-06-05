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

builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobRepository, JobRepository>();

builder.Services.AddScoped<ISubmissionService, SubmissionService>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();

var dockerConnectionString = Environment.GetEnvironmentVariable("MSSQLConnectionStrings");

// inject our connectionstring into DbContext
//builder.Services.AddDbContext<RecruitingDbContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbConnection"))
//    );

builder.Services.AddDbContext<RecruitingDbContext>(options => options.UseSqlServer(dockerConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

var angularURL = Environment.GetEnvironmentVariable("angularURL");

app.UseCors(policy =>
{
    policy.WithOrigins(angularURL).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
});

app.MapControllers();

app.Run();
