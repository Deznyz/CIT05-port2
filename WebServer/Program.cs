using DataLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvcCore();
builder.Services.AddSingleton<IDataService, DataService>();
builder.Services.AddCors();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();
app.UseCors(
  options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()); app.MapControllers();
app.Run();