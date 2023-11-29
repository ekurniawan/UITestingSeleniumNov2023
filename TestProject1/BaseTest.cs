using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace TestProject1;

public class BaseTest
{
    private IWebDriver driver;

    protected IWebDriver GetDriver()
    {
        return driver;
    }

    [SetUp]
    public void Setup()
    {
        driver = CreateDriver(ConfigurationProvider.Configuration["browser"]);
        driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        driver.Navigate().GoToUrl("http://localhost:4200");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    private IWebDriver CreateDriver(string browserName)
    {
        switch (browserName.ToLower())
        {
            case "chrome":
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments(GetBrowserArguments());
                return new ChromeDriver(chromeOptions);
            case "firefox":
                var firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArguments(GetBrowserArguments());
                return new FirefoxDriver(firefoxOptions);
            case "safari":
                //var safariOptions = new SafariOptions();
                //safariOptions.AddArguments(GetBrowserArguments());
                return new SafariDriver();
            case "edge":
                var edgeOptions = new EdgeOptions();
                edgeOptions.AddArguments(GetBrowserArguments());
                return new EdgeDriver(edgeOptions);
            default:
                throw new Exception("Browser not supported");
        }
    }

    private string[] GetBrowserArguments()
    {
        if (ConfigurationProvider.Configuration["browserArguments"] != null)
        {
            return ConfigurationProvider.Configuration["browserArguments"].Split(",");
        }
        return Array.Empty<string>();
    }
}
