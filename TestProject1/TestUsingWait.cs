using TestProject1.Pages;

namespace TestProject1;

public class TestUsingWait : BaseTest
{
    private OrderPage orderPage;

    [SetUp]
    public new void Setup()
    {
        orderPage = new OrderPage(GetDriver());
        GetDriver().Navigate().GoToUrl("http://localhost:4200/order-delay");
        GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
    }

    [Test]
    public void WaitingForOrderToProccessTest()
    {
        Thread.Sleep(2000);
        orderPage.EnterName("Erick Kurniawan");
        orderPage.SelectWorkshop(1);
        orderPage.ClickAddButton();
        orderPage.ScrollToOrderButton();
        var orderStatusPage = orderPage.ClickOrderButton();

        Assert.That(orderStatusPage.GetOrderSuccessMessageText(), Is.EqualTo("Your order has been successfully created!"));
    }

    [Test]
    public void ExplicitWaitingForOrderToProccessTest()
    {
        Thread.Sleep(2000);
        orderPage.EnterName("Erick Kurniawan");
        orderPage.SelectWorkshop(1);
        orderPage.ClickAddButton();
        orderPage.ScrollToOrderButton();
        var orderStatusPage = orderPage.ClickOrderButton();

        GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        orderStatusPage.WaitForOrderSuccessMessage(TimeSpan.FromSeconds(20));

        Assert.That(orderStatusPage.GetOrderSuccessMessageText(), Is.EqualTo("Your order has been successfully created!"));
    }
}
