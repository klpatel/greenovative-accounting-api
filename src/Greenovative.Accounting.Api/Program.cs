using Greenovative.Accounting.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureSwagger();
builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddMiddleware();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json");
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
//app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/Greenovative.Identity.App/swagger.json", "Greenovative.Identity.App");
    c.SwaggerEndpoint("/swagger/Greenovative.Clients.App/swagger.json", "Greenovative.Clients.App");
    //c.SwaggerEndpoint("/swagger/LotoMate.Lottery.API/swagger.json", "Lottery Module Api");
    //c.SwaggerEndpoint("/swagger/LotoMate.Lottery.Reports/swagger.json", "Lottery Module Reports");
});

app.UseHttpsRedirection();

app.UseAuthentication().UseAuthorization();

app.MapControllers();
app.UseExceptionHandler("/errors");

app.Run();
