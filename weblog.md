### 09/10/2018

Steps to prepare ASP.NET core web backend project from *ASP.NET Core 2 and Angular 5 book*:

1. In Visual Studio, create a new ASP.NET Core Web Application Project.
2. Disable static file caching for dev builds in Startup.cs by putting in the following code:
```csharp
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = (context) =>
    {
        // Disable caching for all static files. 
        context.Context.Response.Headers["Cache-Control"] = "no-cache,    
         no-store";
        context.Context.Response.Headers["Pragma"] = "no-cache";
        context.Context.Response.Headers["Expires"] = "-1";
    }
});
```
3. Add the following development static file configs in appsettings.Development.json:
```json
  "StaticFiles": {
    "Headers": {
      "Cache-Control": "no-cache, no-store",
      "Pragma": "no-cache",
      "Expires": "-1"
    }
  }
```
4. Add the following production static file configs in appsettings.json:
```json
  "StaticFiles": {
    "Headers": {
      "Cache-Control": "max-age=3600",
      "Pragma": "cache",
      "Expires": null
    }
  }
```
5. Remove counter and fetch-data folders from ClientApp\src\app folder.
6. Remove all counter and fetch-data references from ClientApp\src\app\app.module.ts.
7. Remove Counter and Fetch Data HTML content from the html file ClientApp\src\app\components\navmenu\navmenu.component.html.
8. Replace the default project page text in the hmtl file /ClientApp/app/components/home/home.component.html with a simpler message:
```html
<h1>Greetings, stranger!</h1>
<p>This is what you get for messing up with .NET Core and Angular.</p>
```
9. Begin creating view models for representing response data for various views of the model.
10. Begin creating controllers for returning response data as serialized jSON.