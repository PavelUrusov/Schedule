using System.Security.Claims;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;
using WorkSchedule.WebAPI;
using WorkSchedule.WebAPI.Utilities;
using WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

var builder = WebApplication.CreateBuilder(args);

//Getting service settings from the application configuration file
var tokenValidationPrincipal =
    builder.Configuration.GetSection("TokenValidationPrincipal").Get<TokenValidationPrincipal>();
var connectionString = builder.Configuration["ConnectionString"];

//Adding services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenWithAuth();
builder.Services.AddDatabaseContext(connectionString);
builder.Services.AddScoped(typeof(IWorkScheduleRepository<,>), typeof(WorkScheduleWorkScheduleRepository<,>));
builder.Services.AddIdentityService();
builder.Services.AddBearerAuthenticationExtension(tokenValidationPrincipal);
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy(Roles.Admin, b => { b.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, Roles.Admin)); });
    opt.AddPolicy(Roles.User, b =>
    {
        b.RequireAssertion(x =>
            x.User.HasClaim(ClaimTypes.Role, Roles.User) || x.User.HasClaim(ClaimTypes.Role, Roles.Admin));
    });
});

//Adding Options 
builder.Services.Configure<TokenValidationPrincipal>(builder.Configuration.GetSection("TokenValidationPrincipal"));
builder.Services.Configure<AccessTokenPrincipal>(builder.Configuration.GetSection("AccessTokenPrincipal"));
builder.Services.Configure<RefreshTokenPrincipal>(builder.Configuration.GetSection("RefreshTokenPrincipal"));
//Building app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();