using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextdatadetails;
using WebApplication1.Interfaceses;
using WebApplication1.middleware;
using WebApplication1.Repositories;
using WebApplication1.Serviceses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Dbconnect>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services and repositories
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
builder.Services.AddScoped<IGetWdlCompletionRepository, GetWdlComputation_Repository>();
builder.Services.AddScoped<IGetWdlCompletionService, GetWdlComputedService>();
builder.Services.AddScoped<IUpdateWdlComputationRepository, UpdateComputationRepository>();
builder.Services.AddScoped<IUpdateWdlComputationService, UpdateWdlComputationService>();
builder.Services.AddScoped<IInsertSkillhistoryService, InsertSkillHistroryService>();
builder.Services.AddScoped<IInsertSkillHistroryRepository, InsertSkillHistoryRepository>();
builder.Services.AddSingleton<IAuthenticationInterface, AuthenticationService>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Add Swagger if in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Route-specific middleware for /api/secure
app.MapWhen(context => context.Request.Path.StartsWithSegments("/api/learningDataInfo/WdlComputeddata"), builder =>
{
    builder.UseMiddleware<TokenValidationMiddleware>(); // Use your custom middleware
    builder.UseRouting(); // Add routing to enable endpoint mapping
    builder.UseAuthorization(); // Apply authorization middleware if needed
    builder.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers(); // Map controllers for /api/secure routes
    });
});

// Default routing and controllers
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

