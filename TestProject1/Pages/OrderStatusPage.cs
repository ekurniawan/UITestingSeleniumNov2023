using OpenQA.Selenium;
using TestProject1.Utils;

namespace TestProject1.Pages;

public class OrderStatusPage : BasePage
{
    public OrderStatusPage(IWebDriver driver) : base(driver)
    {
    }

    private IWebElement OrderSuccessMessage => driver.FindElement(By.Id("order-success"));

    public void WaitForOrderSuccessMessage(TimeSpan timeSpan)
    {
        new Wait(driver).WaitForElementToBecomeVisible(() => OrderSuccessMessage, timeSpan);
    }

    public string GetOrderSuccessMessageText()
    {
        return OrderSuccessMessage.Text;
    }
}
