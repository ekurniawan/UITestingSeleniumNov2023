using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using TestProject1.Pages;

namespace TestProject1;

public class SimpleTest : BaseTest
{
    private OrderPage orderPage;

    [SetUp]
    public new void Setup()
    {
        orderPage = new OrderPage(GetDriver());
    }

    [Test]
    [Category("Test without assertion")]
    public void Test1()
    {
        orderPage.EnterName("Erick Kurniawan");
        orderPage.ClickAddButton();
    }

    [Test]
    [Category("Test without assertion")]
    public void TestUsingRelativeLocator()
    {
        orderPage.EnterNotes("something important");
        orderPage.SelectWorkshop(0);
    }

    [Test]
    [Category("Test with assertion")]
    public void TestWithAssertion_1Data()
    {
        orderPage.EnterName("Erick Kurniawan");
        orderPage.ClickAddButton();
        Assert.That(orderPage.GetTotalPrice(), Is.EqualTo("$100.00"), "Total price is correct");
    }

    // [Test]
    // [TestCase("Erick Kurniawan", "$100.00")]
    // [TestCase("Budi Santoso", "$100.00")]
    // [TestCase("Joko Susilo", "$100.00")]
    // public void TestWithAssertion_2Data(string nama, string total)
    // {
    //     GetDriver().FindElement(By.Id("full-name")).SendKeys(nama);
    //     GetDriver().FindElement(By.Id("add-btn")).Click();

    //     var totalPrice = GetDriver().FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
    //     //Assert.AreEqual("$200.00", totalPrice.Text, "Total price is correct");
    //     Assert.That(totalPrice.Text, Is.EqualTo(total), "Total price is correct");
    // }

    // [Test]
    // public void TestUseDoubleClick()
    // {
    //     var nameinput = GetDriver().FindElement(By.Id("full-name"));
    //     nameinput.SendKeys("Erick Kurniawan");

    //     var addButton = GetDriver().FindElement(By.Id("add-btn"));
    //     var actions = new Actions(GetDriver());
    //     actions.DoubleClick(addButton).Perform();

    //     Assert.That(GetDriver().FindElement(By.Id("full-name_validation-error")).Displayed,
    //         Is.True, "Validation error is displayed");
    // }

    // [Test]
    // public void Test_UsingClearText()
    // {

    //     var noteTextArea = GetDriver().FindElement(By.Id("notes"));
    //     noteTextArea.SendKeys("something important");
    //     noteTextArea.Clear();
    //     noteTextArea.SendKeys("replace text after clear");

    //     Assert.That(noteTextArea.GetAttribute("value"),
    //         Is.EqualTo("replace text after clear"));
    // }

    // // [Test]
    // // public void Test_UsingUpload()
    // // {
    // //     var photoInput = GetDriver().FindElement(By.Id("photo"));
    // //     photoInput.SendKeys(Path.GetFullPath(Path.Join("Data", "photo.png")));

    // //     Assert.That(photoInput.GetAttribute("value"),
    // //         Is.EqualTo(Path.GetFullPath(Path.Join("Data", "photo.png"))));
    // // }

    // [Test]
    // public void Test_UsingPressing()
    // {
    //     var includeLuchDropdown = GetDriver().FindElement(By.Id("include-lunch"));
    //     var includeLunchSelect = new SelectElement(includeLuchDropdown);
    //     includeLunchSelect.SelectByText("Yes");

    //     Assert.That(includeLunchSelect.SelectedOption.Text,
    //         Is.EqualTo("Yes"));
    // }
}
