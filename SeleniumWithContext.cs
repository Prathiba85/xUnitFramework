using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.Clients;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnitDemo
{
    [Collection("Sequence")]
    public class SeleniumWithContext : IClassFixture<WebDriverfixtures>
    {
        private WebDriverfixtures webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;
       

        public SeleniumWithContext(WebDriverfixtures webDriverFixture,ITestOutputHelper testoutputHelper) {

            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testoutputHelper;

        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestRegisterUser(string username, string password,string confirmpassewrd, string email)
        {
            var driver = webDriverFixture.ChromeDriver;
            // Console.WriteLine("First test");
            webDriverFixture.ChromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmpassewrd);
            driver.FindElement(By.Id("Email")).SendKeys(email);
            var exception = Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.CssSelector(".btn-default")).Click());
            Assert.Contains("no such element: Unable",exception.Message);
            //exception.Message.Should().Contain("no such element: Unable");
            testOutputHelper.WriteLine("Test Completed");
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] {"Karthick","KarthikPassword","KarthickPassword","Kathick@gmail.com"},
            new object[] {"Prathiba","PratibaPassword","PrathibaPassword","Prathiba@gmail.com"},
        };
    }
}
