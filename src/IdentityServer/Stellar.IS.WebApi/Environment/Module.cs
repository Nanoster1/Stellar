namespace Stellar.IS.WebApi.Environment;

public static class Module
{
    public static IWebHostEnvironment AddStellarEnvironment(this IWebHostEnvironment environment)
    {
        return environment;
    }
}