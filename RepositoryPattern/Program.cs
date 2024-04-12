using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RepositoryPattern.Filters;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;
using RepositoryPattern.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Iss"],
            ValidAudience = builder.Configuration["Jwt:Aud"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddScoped<IPhimRepository,PhimRepository>();
builder.Services.AddScoped<IGenericRepository<Hangphim>,HangphimRepository>();
builder.Services.AddScoped<IGenericRepository<Loaiphim>, LoaiPhimRepository>();
builder.Services.AddScoped<IGenericRepository<Tapphim>, TapPhimRepository>();
builder.Services.AddScoped<PhimService>();
builder.Services.AddScoped<IAuthenRepository, AuthenRepository>();
builder.Services.AddScoped<AuthenService>();
builder.Services.AddScoped<IGenericRepository<Binhluan>, CommentsRepository>(); 
builder.Services.AddScoped<CommentService>();   
builder.Services.AddScoped<IGenericRepository<Danhgia>,ReviewRepository>();
builder.Services.AddScoped<ReviewService>();

builder.Services.AddScoped<AuthenFilter>();
builder.Services.AddScoped<testFilter>();
builder.Services.AddScoped<CommentFilter>();
builder.Services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();

}
app.UseAuthentication();

app.UseAuthorization();

app.UseCors(options =>
           options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();

app.Run();
