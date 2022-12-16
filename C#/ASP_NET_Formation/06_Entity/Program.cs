using _06_Entity.DAO;
using _06_Entity.Models;
using _06_Entity.Services;
using _06_Entity.Settings;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// -- NLog
// Installer NLog.Web.AspNetCore
// Créer nlog.config
// dans les propriétés de nlog.config choisir "copier dans le répertoire de sortie" : "copier si plus récent"
// Ajoute Nlog à liste des "Logging Provider"

builder.Logging.AddNLog();
// Add services to the container.
builder.Services.AddControllersWithViews();

// -------------------------------------------
// ON S'ABONNE AU SERVICE AddDbContext
// -------------------------------------------

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("MailSettings"));

var mailSettings = builder.Configuration.GetSection("MailSettings");

builder.Services.Add(new ServiceDescriptor(typeof(EmailSettings),
                                               c => new EmailSettings()
                                               {
                                                   Mail = mailSettings.GetValue<string>("Mail"),
                                                   DisplayName = mailSettings.GetValue<string>("DisplayName"),
                                                   Password = mailSettings.GetValue<string>("Password"),
                                                   Host = mailSettings.GetValue<string>("Host"),
                                                   Port = mailSettings.GetValue<int>("Port")
                                               }, ServiceLifetime.Transient));
// Pour pouvoir envoyer des emails 
builder.Services.AddScoped<IEmailService, EmailService>();

// ----------------- Pour accéder à la couche d'accès aux données des produits
builder.Services.AddScoped<IProductDAO, ProductDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    app.UseStatusCodePagesWithReExecute("/Error/{0}"); // redirige vers l'url /Error/{StatusCode}
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
