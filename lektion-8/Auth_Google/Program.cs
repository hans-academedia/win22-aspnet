using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = "1052416593218-e1lfs8nv62hh7iq7hsdhfj3qlnqfjea6.apps.googleusercontent.com";
    options.ClientSecret = "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";
    options.CallbackPath = "/signin-google";
})
.AddFacebook(facebookOptions =>
{
    facebookOptions.AppId = "";
    facebookOptions.AppSecret = "";
});
builder.Services.AddControllersWithViews();




var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
