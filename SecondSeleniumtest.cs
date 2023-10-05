using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace XUnitDemo
{
    [Collection("Sequence")]
    public class SecondSeleniumtest : IClassFixture<WebDriverfixtures>
    {
        private WebDriverfixtures webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;


        public SecondSeleniumtest(WebDriverfixtures webDriverFixture, ITestOutputHelper testoutputHelper)
        {

            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testoutputHelper;

        }

        [Fact]
        public void ClassFixtureTestNavigate()
        {
            // Console.WriteLine("First test");
            testOutputHelper.WriteLine("First Test");
            webDriverFixture.ChromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
            var anchor = webDriverFixture.ChromeDriver.FindElements(By.TagName("a"));
            //anchor.Should().HaveCountGreaterThan(2);

        }
        [Theory]
        [InlineData("admin", "password")]
        [InlineData("admin", "password2")]
        [InlineData("admin", "password3")]
        public void TestLoginwithFillData(string username, string password)
        {
            var driver = webDriverFixture.ChromeDriver;
            // Console.WriteLine("First test");
            webDriverFixture.ChromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn-default")).Click();
            testOutputHelper.WriteLine("Test Completed");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestRegisterUser(string username, string password, string confirmpassewrd, string email)
        {
            var driver = webDriverFixture.ChromeDriver;
            // Console.WriteLine("First test");
            webDriverFixture.ChromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmpassewrd);
            driver.FindElement(By.Id("Email")).SendKeys(email);

            testOutputHelper.WriteLine("Test Completed");
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] {"Karthick","KarthikPassword","KarthickPassword","Kathick@gmail.com"},
            new object[] {"Prathiba","PratibaPassword","PrathibaPassword","Prathiba@gmail.com"},
             new object[] {"Praahanth", "PraahanthPassword", "PraahanthPassword", "Prashanth@gmail.com"},
        };
    }

    public class WebDriverfixture
    {
    }
}

