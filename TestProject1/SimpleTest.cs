using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace TestProject1;

public class SimpleTest
{
    private IWebDriver driver;

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

    // [Test]
    // public void Test_UsernameOrPasswordIsWrong()
    // {
    //     driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
    //     driver.FindElement(By.Id("password")).SendKeys("secret");
    //     driver.FindElement(By.Id("login-button")).Click();

    //     var pesan = driver.FindElement(By.CssSelector("h3[data-test='error']"));
    //     Assert.That(pesan.Text,
    //         Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
    // }

    [Test]
    public void Test2()
    {
        driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        driver.Navigate().GoToUrl("http://localhost:4200");
        driver.FindElement(RelativeBy.WithLocator(By.TagName("textarea"))
        .Below(By.Id("full-name"))).SendKeys("something important");

        driver.FindElements(RelativeBy.WithLocator(By.CssSelector("input[type='checkbox']"))
        .Below(By.Id("full-name")))[1].Click();
    }

    [Test]
    public void TestWithAssertion_1Data()
    {
        driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        driver.Navigate().GoToUrl("http://localhost:4200");
        driver.FindElement(By.Id("full-name")).SendKeys("Erick Kurniawan");
        //driver.FindElement(By.Id("add-btn")).Click();

        var addButton = driver.FindElement(By.Id("add-btn"));
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", addButton);

        var totalPrice = driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
        //Assert.AreEqual("$200.00", totalPrice.Text, "Total price is correct");
        Assert.That(totalPrice.Text, Is.EqualTo("$100.00"), "Total price is correct");
    }

    [Test]
    [TestCase("Erick Kurniawan", "$100.00")]
    [TestCase("Budi Santoso", "$100.00")]
    [TestCase("Joko Susilo", "$100.00")]
    public void TestWithAssertion_2Data(string nama, string total)
    {
        driver.FindElement(By.Id("full-name")).SendKeys(nama);
        driver.FindElement(By.Id("add-btn")).Click();

        var totalPrice = driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
        //Assert.AreEqual("$200.00", totalPrice.Text, "Total price is correct");
        Assert.That(totalPrice.Text, Is.EqualTo(total), "Total price is correct");
    }

    [Test]
    public void TestUseDoubleClick()
    {
        var nameinput = driver.FindElement(By.Id("full-name"));
        nameinput.SendKeys("Erick Kurniawan");

        var addButton = driver.FindElement(By.Id("add-btn"));
        var actions = new Actions(driver);
        actions.DoubleClick(addButton).Perform();

        Assert.That(driver.FindElement(By.Id("full-name_validation-error")).Displayed,
            Is.True, "Validation error is displayed");
    }

    [Test]
    public void Test_UsingClearText()
    {
        driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        driver.Navigate().GoToUrl("http://localhost:4200");

        var noteTextArea = driver.FindElement(By.Id("notes"));
        noteTextArea.SendKeys("something important");
        noteTextArea.Clear();
        noteTextArea.SendKeys("replace text after clear");

        Assert.That(noteTextArea.GetAttribute("value"),
            Is.EqualTo("replace text after clear"));
    }

    [Test]
    public void Test_UsingUpload()
    {
        var photoInput = driver.FindElement(By.Id("photo"));
        photoInput.SendKeys(Path.GetFullPath(Path.Join("Data", "photo.png")));

        Assert.That(photoInput.GetAttribute("value"),
            Is.EqualTo(Path.GetFullPath(Path.Join("Data", "photo.png"))));
    }

    [Test]
    public void Test_UsingPressing()
    {
        driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        driver.Navigate().GoToUrl("http://localhost:4200");

        var includeLuchDropdown = driver.FindElement(By.Id("include-lunch"));
        var includeLunchSelect = new SelectElement(includeLuchDropdown);
        includeLunchSelect.SelectByText("Yes");

        Assert.That(includeLunchSelect.SelectedOption.Text,
            Is.EqualTo("Yes"));
    }
}
