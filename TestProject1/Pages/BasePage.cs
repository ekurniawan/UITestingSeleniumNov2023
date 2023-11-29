using OpenQA.Selenium;

namespace TestProject1.Pages;

public class BasePage
{
    protected IWebDriver driver;
    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    protected void ScrollToElement(IWebElement element)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        Thread.Sleep(500);
    }
}
