using WorkSchedule.WebAPI.Utilities.Configs;
using WorkSchedule.WebAPI.Utilities.Extensions.ToApplicationBuilder;
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
builder.Services.AddRepositories();
builder.Services.AddScheduleServices();
builder.Services.AddIdentityService();
builder.Services.AddBearerAuthenticationExtension(tokenValidationPrincipal);
builder.Services.AddAuthorizationWithPolicy();
builder.Services.AddAutomapper();

//Adding Options 
builder.Services.AddConfigureSettings(builder.Configuration);

//Building app
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.AddCustomCors();
//app.UseErrorHandling();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();