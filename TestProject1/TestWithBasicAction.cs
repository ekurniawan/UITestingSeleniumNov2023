using OpenQA.Selenium;
using TestProject1.Pages;

namespace TestProject1;

public class TestWithBasicAction : BaseTest
{
    private OrderPage orderPage;

    [SetUp]
    public new void Setup()
    {
        orderPage = new OrderPage(GetDriver());
    }

    [Test]
    public void ScrollingToButtonOrderTest()
    {
        orderPage.EnterName("Erick Kurniawan");
        orderPage.SelectWorkshop(1);
        orderPage.ClickAddButton();

        orderPage.ScrollToOrderButton();
        orderPage.ClickOrderButton();
        Thread.Sleep(2000);
        Assert.That(GetDriver().Url, Contains.Substring("success"));
    }

    [Test]
    public void SampleReturnAlert()
    {
        GetDriver().Navigate().GoToUrl("http://localhost:4200/show-alert");
        orderPage.EnterName("Erick Kurniawan");
        orderPage.ClickAddButton();

        var alertWindows = GetDriver().SwitchTo().Alert();
        alertWindows.Accept();

        orderPage.ScrollToTicketTableRemoveButton(0);
        orderPage.ClickOnTicketRemoveButton(0);

        var confirmationWindows = GetDriver().SwitchTo().Alert();
        confirmationWindows.Dismiss();

        Assert.That(orderPage.GetOrderTicketCount(), Is.EqualTo(1));
    }
}
