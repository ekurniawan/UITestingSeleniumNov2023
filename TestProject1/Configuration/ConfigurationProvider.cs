using Microsoft.Extensions.Configuration;

namespace TestProject1;

public class ConfigurationProvider
{
    private static ConfigurationManager configurtion;
    public static ConfigurationManager Configuration
    {
        get
        {
            if (configurtion == null)
            {
                configurtion = new ConfigurationManager();
                configurtion.AddJsonFile($"appsettings.local.json", optional: true, false);
            }
            return configurtion;
        }
    }
}
