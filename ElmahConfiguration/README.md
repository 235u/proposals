# ELMAH Configuration

An ASP.NET MVC (5.2.7) application, 

- targeting .NET Framework (4.7)
- integrating [Elmah.Mvc](https://github.com/alexbeletsky/elmah-mvc) (2.1.2),
- live at https://elmahconfiguration.azurewebsites.net, 
- using `SqlServer` for data persistence in [default configuration](ElmahConfiguration/Web.config) (for local testing),
- and using `SQLite` in [debug configuration](ElmahConfiguration/Web.Debug.config) (for hosting in Azure, with enabled [remote access](https://code.google.com/archive/p/elmah/wikis/SecuringErrorLogPages.wiki)).

## Procedure

1. Add `Elmah.Mvc` via [NuGet](https://www.nuget.org/packages/Elmah.MVC/) to the host web application.
2. Set the [ErrorLog implementation](https://elmah.github.io/a/error-log-implementations/) to `Elmah.SqlErrorLog` in the `Web.config` (of the host web application) and provide the name of the `ConnectionString` to use.

```xml
<elmah>
  <errorLog type="Elmah.SqlErrorLog, Elmah" connectionStringName="elmah" />
</elmah>
```

3. Define the `ConnectionString` if not done yet.

```xml
<connectionStrings>
  <add name="elmah"
       connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SQLServer.mdf;Integrated Security=True" />
</connectionStrings>
```

4. Update your database schema via [SQLServer.sql](ElmahConfiguration/App_Data/SQLServer.sql) (original [source](https://github.com/elmah/SqlErrorLog)).

![Schema](ElmahConfiguration/Content/Schema.png)

5. Produce errors.
6. Navigate to `/elmah`.

```csharp
public class HomeController : Controller
{
    public ActionResult Index()
    {
        RaiseErrorSignal();
        return RedirectToAction(actionName: "Index", controllerName: "elmah");
    }

    private static void RaiseErrorSignal()
    {
        try
        {
            throw new Exception(message: "Catch Me If You Can");
        }
        catch (Exception e)
        {
            ErrorSignal.FromCurrentContext().Raise(e);
        }
    }
}
```

