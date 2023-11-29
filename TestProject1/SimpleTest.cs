using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace TestProject1;

public class SimpleTest : BaseTest
{
    [Test]
    public void Test2()
    {
        GetDriver().FindElement(RelativeBy.WithLocator(By.TagName("textarea"))
        .Below(By.Id("full-name"))).SendKeys("something important");

        GetDriver().FindElements(RelativeBy.WithLocator(By.CssSelector("input[type='checkbox']"))
        .Below(By.Id("full-name")))[1].Click();
    }

    [Test]
    public void TestWithAssertion_1Data()
    {
        GetDriver().FindElement(By.Id("full-name")).SendKeys("Erick Kurniawan");
        //driver.FindElement(By.Id("add-btn")).Click();

        var addButton = GetDriver().FindElement(By.Id("add-btn"));
        ((IJavaScriptExecutor)GetDriver()).ExecuteScript("arguments[0].click();", addButton);

        var totalPrice = GetDriver().FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
        //Assert.AreEqual("$200.00", totalPrice.Text, "Total price is correct");
        Assert.That(totalPrice.Text, Is.EqualTo("$100.00"), "Total price is correct");
    }

    [Test]
    [TestCase("Erick Kurniawan", "$100.00")]
    [TestCase("Budi Santoso", "$100.00")]
    [TestCase("Joko Susilo", "$100.00")]
    public void TestWithAssertion_2Data(string nama, string total)
    {
        GetDriver().FindElement(By.Id("full-name")).SendKeys(nama);
        GetDriver().FindElement(By.Id("add-btn")).Click();

        var totalPrice = GetDriver().FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
        //Assert.AreEqual("$200.00", totalPrice.Text, "Total price is correct");
        Assert.That(totalPrice.Text, Is.EqualTo(total), "Total price is correct");
    }

    [Test]
    public void TestUseDoubleClick()
    {
        var nameinput = GetDriver().FindElement(By.Id("full-name"));
        nameinput.SendKeys("Erick Kurniawan");

        var addButton = GetDriver().FindElement(By.Id("add-btn"));
        var actions = new Actions(GetDriver());
        actions.DoubleClick(addButton).Perform();

        Assert.That(GetDriver().FindElement(By.Id("full-name_validation-error")).Displayed,
            Is.True, "Validation error is displayed");
    }

    [Test]
    public void Test_UsingClearText()
    {

        var noteTextArea = GetDriver().FindElement(By.Id("notes"));
        noteTextArea.SendKeys("something important");
        noteTextArea.Clear();
        noteTextArea.SendKeys("replace text after clear");

        Assert.That(noteTextArea.GetAttribute("value"),
            Is.EqualTo("replace text after clear"));
    }

    // [Test]
    // public void Test_UsingUpload()
    // {
    //     var photoInput = GetDriver().FindElement(By.Id("photo"));
    //     photoInput.SendKeys(Path.GetFullPath(Path.Join("Data", "photo.png")));

    //     Assert.That(photoInput.GetAttribute("value"),
    //         Is.EqualTo(Path.GetFullPath(Path.Join("Data", "photo.png"))));
    // }

    [Test]
    public void Test_UsingPressing()
    {
        var includeLuchDropdown = GetDriver().FindElement(By.Id("include-lunch"));
        var includeLunchSelect = new SelectElement(includeLuchDropdown);
        includeLunchSelect.SelectByText("Yes");

        Assert.That(includeLunchSelect.SelectedOption.Text,
            Is.EqualTo("Yes"));
    }
}
