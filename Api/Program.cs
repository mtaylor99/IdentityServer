using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Authentication.Authority"];
        options.Audience = builder.Configuration["Authentication.Audience"];

        options.TokenValidationParameters.ValidateAudience = true;
        options.TokenValidationParameters.ValidateIssuer = true;
        options.TokenValidationParameters.ValidateIssuerSigningKey = true;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", authorizationPolicyBuilder =>
    {
        authorizationPolicyBuilder.RequireAuthenticatedUser().RequireClaim("scope", "https://localhost:5003/api");
    });
});

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API", Version = "v1"
    });

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            ClientCredentials = new OpenApiOAuthFlow
            {
                TokenUrl = new Uri($"{builder.Configuration["Authentication:Authority"]}/connect/token"),
                Scopes = { { "https://localhost:5003/api" , "API" } }
            }
        }
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
           new OpenApiSecurityScheme
           {
               Reference = new OpenApiReference
               {
                   Type = ReferenceType.SecurityScheme,
                   Id = "oauth2"
               }
           },
           new List<string>
           {
               "https://localhost:5003/api"
           }
       }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
