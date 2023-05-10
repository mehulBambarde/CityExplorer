using CityInfo.API.Services;
using Dbcontexts;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        policy =>
        {
            policy.WithOrigins("http://localhost:62255");
        });

    options.AddPolicy("AnotherPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:62255",
            "http://localhost:51699")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<CityInfoContext>(dbContextOptions => dbContextOptions.UseSqlite("Data Source=CityInfo.db"));


builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();



app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors();


app.UseEndpoints(endpoints=>{
    
app.MapControllers();
}
    
);

app.Run();
