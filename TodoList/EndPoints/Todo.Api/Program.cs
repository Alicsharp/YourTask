using Common.Application;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Todo.Api.Infrastructure;
using Todo.Api.Infrastructure.JwtUtil;
using TodoList.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
   .ConfigureApiBehaviorOptions(option =>
   {
       option.InvalidModelStateResponseFactory = (context =>
       {
           var result = new ApiResult()
           {
               IsSuccess = false,
               MetaData = new()
               {
                   AppStatusCode = AppStatusCode.BadRequest,
                   Message = ModelStateUtil.GetModelStateErrors(context.ModelState)
               }
           };
           return new BadRequestObjectResult(result);
       });
   });
builder.Services.AddSwaggerGen(option =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Enter Token",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});
builder.Services.AddJwtAuthentication(builder.Configuration);
ToDoBootstrapper.RegisterToDoDependency(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));
// Add services to the container.
CommonBootstrapper.Init(builder.Services);
builder.Services.RegisterApiDependency( );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // احراز هویت
app.UseAuthorization();
app.MapControllers();

app.Run();
