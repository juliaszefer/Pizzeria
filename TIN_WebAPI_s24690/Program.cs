using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IZamowienieService, ZamowienieService>();
builder.Services.AddTransient<IUzytkownikService, UzytkownikService>();
builder.Services.AddTransient<ISkladnikService, SkladnikService>();
builder.Services.AddTransient<IRolaService, RolaService>();
builder.Services.AddTransient<IPizzaService, PizzaService>();
builder.Services.AddTransient<IOsobaService, OsobaService>();
builder.Services.AddTransient<INapojService, NapojService>();
builder.Services.AddTransient<IDodatekService, DodatekService>();
builder.Services.AddTransient<IAdresService, AdresService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PizzeriaDbContext>(opt =>
{
    opt.UseMySql(builder.Configuration.GetConnectionString("DbConnString"), 
        new MySqlServerVersion(new Version(8, 2, 0))); 
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
);

// builder.WebHost.UseUrls("http://localhost:5000");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        corsBuilder =>
        {
            corsBuilder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();