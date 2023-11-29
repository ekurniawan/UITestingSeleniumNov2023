using OpenQA.Selenium;

namespace TestProject1.Pages;

public class OrderPage : BasePage
{
    private IWebDriver driver;
    public OrderPage(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }

    private IWebElement Name => driver.FindElement(By.Id("full-name"));
    private IWebElement AddButton => driver.FindElement(By.Id("add-btn"));
    private IWebElement TotalPrice => driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));

    private IWebElement Notes => driver.FindElement(RelativeBy
                                .WithLocator(By.TagName("textarea"))
                                .Below(Name));

    private IWebElement OrderButton => driver.FindElement(By.Id("order-btn"));

    private List<IWebElement> Workshop => driver.FindElements(RelativeBy.WithLocator(
            By.CssSelector("input[type='checkbox']")).Below(Name)).ToList();

    private List<IWebElement> OrderTableItems => driver.FindElements(
        By.CssSelector(".order-summary tbody tr")).ToList();

    public void EnterName(string name)
    {
        Name.SendKeys(name);
    }

    public void ClickAddButton()
    {
        AddButton.Click();
    }

    public string GetTotalPrice()
    {
        return TotalPrice.Text;
    }

    public void EnterNotes(string notes)
    {
        Notes.SendKeys(notes);
    }

    public void SelectWorkshop(int workshopIndex)
    {
        Workshop[workshopIndex].Click();
    }

    public void ScrollToOrderButton()
    {
        ScrollToElement(OrderButton);
    }

    public OrderStatusPage ClickOrderButton()
    {
        OrderButton.Click();
        return new OrderStatusPage(driver);
    }

    public int GetOrderTicketCount()
    {
        return OrderTableItems.Count;
    }

    public void ScrollToTicketTableRemoveButton(int index)
    {
        ScrollToElement(OrderTableItems[index]);
    }

    public void ClickOnTicketRemoveButton(int index)
    {
        OrderTableItems[index].FindElement(By.TagName("button")).Click();
    }
}