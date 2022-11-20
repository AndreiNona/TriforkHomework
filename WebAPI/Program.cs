using Application;
using Application.DataBase;
using Application.Implementation;
using Contracts;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            //Needed for CORS in general
            policy.WithOrigins("https://localhost:44492",
                "https://localhost:7082","http://localhost:5279","https://localhost:7082/User/Add");
            //Needed for CORS when sending object
            policy.WithHeaders("content-type");
        });
});
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<UserFileContext>();
builder.Services.AddScoped<IUserDAO, UserFileDao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Allows CORS 
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
