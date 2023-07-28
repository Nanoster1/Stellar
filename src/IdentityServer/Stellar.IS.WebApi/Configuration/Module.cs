namespace Stellar.IS.WebApi.Configuration;

public static class Module
{
    public static ConfigurationManager AddStellarISConfiguration(this ConfigurationManager manager)
    {
        manager.SetBasePath(AppContext.BaseDirectory);

        manager.AddYamlFile(
            path: "appsettings.yaml",
            optional: false,
            reloadOnChange: true);

        return manager;
    }
}