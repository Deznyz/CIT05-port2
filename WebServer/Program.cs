using DataLayer;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddMvcCore();
//builder.Services.AddScoped<DataLayer.DataService>();
builder.Services.AddSingleton<IDataService, DataService>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();
app.UseCors(
  options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()); app.MapControllers();
app.Run();