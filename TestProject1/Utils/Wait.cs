using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject1.Utils;

public class Wait
{
    private readonly IWebDriver driver;
    public Wait(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void WaitForElementToBecomeVisible(Func<IWebElement> element, TimeSpan timeSpan)
    {
        var wait = new WebDriverWait(driver, timeSpan);
        wait.Until((_) => element.Invoke().Displayed);
    }

    public IWebElement WaitForElementToBecomeVisible(By by, TimeSpan timeSpan)
    {
        var wait = new WebDriverWait(driver, timeSpan);
        return wait.Until((_) =>
        {
            var element = driver.FindElement(by);
            if (element.Displayed)
            {
                return element;
            }
            return null;
        });
    }

}
