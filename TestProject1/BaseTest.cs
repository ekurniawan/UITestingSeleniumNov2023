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
        driver = new SafariDriver();
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
                return new ChromeDriver();
            case "firefox":
                return new FirefoxDriver();
            case "safari":
                return new SafariDriver();
            case "edge":
                return new EdgeDriver();
            default:
                throw new Exception("Browser not supported");
        }
    }
}
