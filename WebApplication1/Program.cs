using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.DbContextdatadetails;
using WebApplication1.Interfaceses;
using WebApplication1.Repositories;
using WebApplication1.Serviceses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Dbconnect>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ILearnerDataRepositories, LearnerDataRepository>();
builder.Services.AddScoped<IlearningDataService, LearnerDataServices>();

builder.Services.AddScoped<IGetCourserelateddataRepository, GetCourserelatedRepository>();
builder.Services.AddScoped<IGetCourserelateddataService, GetCourserelatedService>();

builder.Services.AddScoped<IGetCourseInfoRepository, GetCourseInfoRepository>();
builder.Services.AddScoped<IGetCourseInfoService, GetCourseInfoService>();

builder.Services.AddScoped<IGetSkillInfoService, GetSkillInfoService>();
builder.Services.AddScoped<IGetSkillInfoRepository, GetSkillInfoRepository>();
builder.Services.AddScoped<IInsertWdlComputedDataRepository, WdlInsertRepository>();
builder.Services.AddScoped<IInsertWdlComputedDataservice, WdlInsertdataService>();
builder.Services.AddScoped<IWdldataprocessingService, WdlDataProcessService>();
builder.Services.AddScoped<IGetWdlCompletionRepository, GetWdlComputation_Repository >();
builder.Services.AddScoped<IGetWdlCompletionService, GetWdlComputedService>();
builder.Services.AddScoped<IUpdateWdlComputationRepository, UpdateComputationRepository>();
builder.Services.AddScoped<IUpdateWdlComputationService, UpdateWdlComputationService>();
//builder.Services.AddScoped<IInsertSkillHistroryRepository,InsertSkillHistoryRepository>();
//builder.Services.AddScoped<IInsertSkillhistoryService, InsertSkillHistroryService>();
builder.Services.AddScoped<IInsertSkillhistoryService, InsertSkillHistroryService>();
builder.Services.AddScoped<IInsertSkillHistroryRepository, InsertSkillHistoryRepository >();
builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen();

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
