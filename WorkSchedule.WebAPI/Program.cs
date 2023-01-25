using Microsoft.EntityFrameworkCore;
using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WorkScheduleDbContext>(opt =>
{
    opt.UseLazyLoadingProxies().UseNpgsql(builder.Configuration["ConnectionString"]);
});
builder.Services.AddScoped(typeof(IRepository<,>), typeof(WorkScheduleRepository<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();