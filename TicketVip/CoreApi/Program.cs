using CoreApi.Service;
using CoreApi.Setting;
using Ecommerce.Application.Ioc;
using Ecommerce.Infrastructure.Sql.Ioc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Stripe;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;


var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMemoryCache();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureSqlServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add services to the container.
// For Identity

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});


//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("V1", new OpenApiInfo
//    {
//        Version = "V1",
//        Title = "WebAPI",
//        Description = "Product WebAPI"
//    });
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Name = "Authorization",
//        Description = "Bearer Authentication with JWT Token",
//        Type = SecuritySchemeType.Http
//    });
//    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
//        {
//            new OpenApiSecurityScheme {
//                Reference = new OpenApiReference {
//                    Id = "Bearer",
//                        Type = ReferenceType.SecurityScheme
//                }
//            },
//            new List < string > ()
//        }
//    });
//});

//builder.Services.AddScoped<ICacheService, CacheService>();
//builder.Services.AddDbContext<DbContextClass>();

//builder.Services.AddAuthentication(opt =>
//{
//    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = CoreApi.Helpers.ConfigurationManager.AppSetting["JWT:ValidIssuer"],
//        ValidAudience = CoreApi.Helpers.ConfigurationManager.AppSetting["JWT:ValidAudience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(CoreApi.Helpers.ConfigurationManager.AppSetting["JWT:Secret"]))
//    };
//});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
//builder.Services.AddTransient<IMailService, MailService>();

//builder.Services..AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "_101SendEmailNotificationDoNetCoreWebAPI", Version = "v1" });
//});

builder.Services.AddOptions();                                         // Kích ho?t Options
var mailsettings = builder.Configuration.GetSection("MailSettings");  // ??c config
builder.Services.Configure<MailSettings>(mailsettings);

// ??ng ký SendMailService v?i ki?u Transient, m?i l?n g?i d?ch
// v? ISendMailService m?t ??i t??ng SendMailService t?o ra (?ã inject config)
builder.Services.AddTransient<ISendMailService, SendMailService>();

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
    options.HttpsPort = 5001;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        IHeaderDictionary headers = context.Context.Response.Headers;
        string contentType = headers["Content-Type"];
        if (contentType == "application/x-gzip")
        {
            if (context.File.Name.EndsWith("js.gz"))
            {
                contentType = "application/javascript";
            }
            else if (context.File.Name.EndsWith("css.gz"))
            {
                contentType = "text/css";
            }
            headers.Add("Content-Encoding", "gzip");
            headers["Content-Type"] = contentType;
        };

        // Cache static files for 30 days
        if (!app.Environment.IsDevelopment())
        {
            context.Context.Response.Headers.Append("Cache-Control", "public,max-age=2592000");
            context.Context.Response.Headers.Append("Expires", DateTime.UtcNow.AddDays(30).ToString("R", CultureInfo.InvariantCulture));
        }
    }
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
