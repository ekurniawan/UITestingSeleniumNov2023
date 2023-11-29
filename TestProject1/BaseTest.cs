using OpenQA.Selenium;
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
}
