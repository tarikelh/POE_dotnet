var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------
// --Ajout (abonnement) aux services dont aura besoin l'application--
// ------------------------------------------------------------------

// Add services to the container.
builder.Services.AddControllersWithViews();

// ------------------------------------------------------------------
// ----------------   Build Application   ---------------------------
// ------------------------------------------------------------------
var app = builder.Build();

// ------------------------------------------------------------------
// - CONFIGURATION DU PIPELINE PERMETTANT DE REPONDRE A LA REQUETE --
// ------------------------------------------------------------------

// Le pipeline sp�cifie la mani�re dont l'application doit r�pondre � la requ�te
// Quand l'application recoit une requete de la part du client, la requ�te fait aller/retour � travers le pipeline
// Et plus pr�cis�ment � partir d'un ensemble de middelwares composant ledit pipeline

// Ces middlewares permettent chacun d'adresser un (et un seul) point technique li� au traitement de la requ�te.
// - La gestion des erreuers
// - la gestion des cookies
// - l'authentification
// - la gestion des sessions
// - le routage...
// - ...

// Le passsage de la req�te � travers l'ensemble des middleware permettra de cr�er la r�ponse.
// L'ordre des middleware est tr�s important car ils sont invoqu�s s�quentiellement
// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    // Si pas en environnement de d�veloppement, on redirige vers l'action 'Error' du Controller 'Home'
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); // indique au client qu'on pr�f�re qu'il utilise HTTPS pour faire ces requ�tes
}

app.UseHttpsRedirection(); // Middleware de redirection vers https

app.UseStaticFiles(); // Middleware permettant d'utiliser des ressources statiques (css, js, fichiers...) plac�es dans le dossier 'wwwroot'

app.UseRouting();

app.UseAuthorization();

// Le middleware 'UseRouting' autorise la cr�ation d'un ensemble de 'route'
// La compatibilit� de l'URL de la req�te avec chaque route est successivement test�e jusqu'� ce que l'une d'entre elles matche
// La route qui matche va permettre de router le traitement de la re^qu�te vers : 
// - un controller
// - une action du controller (avec param�tres optionnels)

// D�s lors qu'une route matche, les suivantes ne pas test�es
// Si aucune route ne matche, la requ�te est transf�r�e au middleware suivant.

/*app.MapControllerRoute(
    name: "reverse",
    pattern: "{action=Privacy}/{controller=Home}/{id?}");*/

/*app.MapControllerRoute(
    name: "custom",
    pattern: "{controller=new}/{action=ActionReturnString}/{id?}");*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Middleware de mise en cache
app.UseResponseCaching();
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
        {
            Public = true,
            MaxAge = TimeSpan.FromSeconds(10)
        };

    await next();
});

// -------------------------------------------------------
// ---------------------RUN Application ------------------
// -------------------------------------------------------
app.Run();
