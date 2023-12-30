using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options => {
    options.Cookie.Name = "MyCookieAuth";
    
    // Send annonymous users to the login page
    options.LoginPath = "/account/login";

    // life span cookie 
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
});

builder.Services.AddAuthorization(options => 
{
    // New Policy
    options.AddPolicy("HROnly", policy => {
        // Requirement: a user to come from the HR department
       policy.RequireClaim(ClaimTypes.Role, "HR"); 
    });

    // New Policy
    options.AddPolicy("AdminOnly", policy => {
        // Requirement: a user to come from the Admin department
       policy.RequireClaim(ClaimTypes.Role, "Admin"); 
    });
});
    

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
