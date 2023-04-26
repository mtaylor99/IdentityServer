using System.Reflection;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.Models;
using IdentityServer.Data;
using IdentityServer.Factories;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var identityConnectionString = builder.Configuration.GetConnectionString("Identity");
var identityServerConnectionString = builder.Configuration.GetConnectionString("IdentityServer");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(identityConnectionString,
        optionsBuilder => {
            optionsBuilder.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);

        })
);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddClaimsPrincipalFactory<ApplicationUserClaimsPrincipalFactory>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<ApplicationUser>()
    .AddConfigurationStore(options =>
    {
        options.ResolveDbContextOptions = (serviceProvider, dbContextOptionsBuilder) =>
        {
            dbContextOptionsBuilder.UseSqlServer(identityServerConnectionString,
                optionsBuilder =>
                {
                    optionsBuilder.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                });
        };
    })
    .AddOperationalStore(options =>
    {
        options.ResolveDbContextOptions = (serviceProvider, dbContextOptionsBuilder) =>
        {
            dbContextOptionsBuilder.UseSqlServer(identityServerConnectionString,
                optionsBuilder =>
                {
                    optionsBuilder.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                });
        };
    });

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();

app.MapRazorPages();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();

    await scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
    await scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.MigrateAsync();
    await scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.MigrateAsync();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    if (await userManager.FindByNameAsync("mathew taylor") == null)
    {
        await userManager.CreateAsync(new ApplicationUser
        {
            UserName = "mathew.taylor",
            Email = "mathew.taylor@davies-group.com",
            GivenName = "Mathew",
            FamilyName = "Taylor"
        }, "Password1!");
    }

    var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

    if (!await configurationDbContext.ApiResources.AnyAsync())
    {
        await configurationDbContext.ApiResources.AddAsync(new ApiResource
        {
            Name = Guid.NewGuid().ToString(),
            DisplayName = "API",
            Scopes = new List<string> { "https://localhost:5003/api" }
        }.ToEntity());

        await configurationDbContext.SaveChangesAsync();
    }

    if (!await configurationDbContext.ApiScopes.AnyAsync())
    {
        await configurationDbContext.ApiScopes.AddAsync(new ApiScope
        {
            Name = "https://localhost:5003/api",
            DisplayName = "API",
        }.ToEntity());

        await configurationDbContext.SaveChangesAsync();
    }

    if (!await configurationDbContext.Clients.AnyAsync())
    {
        await configurationDbContext.Clients.AddRangeAsync(new Client
        {
            ClientId = Guid.NewGuid().ToString(),
            ClientSecrets= new List<Secret> { new("secret".Sha512()) },
            ClientName = "Console Application",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes = new List<string> { "https://localhost:5003/api" },
            AllowedCorsOrigins = new List<string> { "https://localhost:5003" }
        }.ToEntity(), new Client
        {
            ClientId = Guid.NewGuid().ToString(),
            ClientSecrets = new List<Secret> { new("secret".Sha512()) },
            ClientName = "Web Application",
            AllowedGrantTypes = GrantTypes.Code,
            AllowedScopes = new List<string> { "openid", "profile", "email", "https://localhost:5003/api" },
            RedirectUris = new List<string> { "https://localhost:7202/signin-oidc" },
            PostLogoutRedirectUris = new List<string> { "https://localhost:7202/signout-callback-oidc" },
        }.ToEntity(), new Client
        {
            ClientId = Guid.NewGuid().ToString(),
            RequireClientSecret = false,
            ClientName = "Single Page Application",
            AllowedGrantTypes = GrantTypes.Code,
            AllowedScopes = new List<string> { "openid", "profile", "email", "https://localhost:5003/api" },
            AllowedCorsOrigins = new List<string> { "https://singlepageapplication:3000" },
            RedirectUris = new List<string> { "https://singlepageapplication:3000/authentication/login-callback" },
            PostLogoutRedirectUris = new List<string> { "https://singlepageapplication:3000/authentication/logout-callback" },
        }.ToEntity());

        await configurationDbContext.SaveChangesAsync();
    }

    if (!await configurationDbContext.IdentityResources.AnyAsync())
    {
        await configurationDbContext.IdentityResources.AddRangeAsync(new IdentityResources.OpenId().ToEntity(),
            new IdentityResources.Profile().ToEntity(),
            new IdentityResources.Email().ToEntity());

        await configurationDbContext.SaveChangesAsync();
    }
}

app.Run();
