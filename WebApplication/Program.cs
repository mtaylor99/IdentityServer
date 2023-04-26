using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddOpenIdConnect(options =>
    {
        options.Authority = "https://localhost:5001"; //AUTHENTICATION__AUTHORITY
        options.ClientId = "009a2287-d4ec-46b9-a51d-349ec810fb9f"; //AUTHENTICATION__CLIENTID
        options.ClientSecret = "secret"; //AUTHENTICATION__CLIENTSECRET
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ResponseType = "code";
        options.Scope.Add("https://localhost:5003/api");
        options.SaveTokens = true;
    });

builder.Services.AddAuthorization();

builder.Services.AddHttpClient();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
