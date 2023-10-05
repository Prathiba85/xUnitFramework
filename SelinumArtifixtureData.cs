using AutoFixture;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnitDemo
{
    public class SelinumArtifixtureData : IClassFixture<WebDriverfixtures>
    {
        private WebDriverfixtures webDriverFixture;
        private ITestOutputHelper testOutputHelper;

        public SelinumArtifixtureData(WebDriverfixtures WebDriverfixture, ITestOutputHelper testoutputHelper)
        {
            this.webDriverFixture = WebDriverfixture;
            this.testOutputHelper = testOutputHelper;

        }
        [Fact]
        public void TestRegisterUser()
        {
            var driver = webDriverFixture.ChromeDriver;
            webDriverFixture.ChromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");

            var userName = new Fixture().Create<string>();
            var password = new Fixture().Create<string>();
            var email = new Fixture().Create<MailAddressGenerator>();

            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys(userName);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(password);
            driver.FindElement(By.Id("Email")).SendKeys(email.ToString());

            //Autofixtures other options


           // testOutputHelper.WriteLine("Test Completed");
        }

        [Fact]
        public void TestRegisterUserwithType()
        {
            var driver = webDriverFixture.ChromeDriver;
            webDriverFixture.ChromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");

            //var model = new Fixture().Create<RegisterUserModel>();
            var fixture = new Fixture();

            //var model = fixture.Build<RegisterUserModel>().Without(x => x.Email).Create();

            var model = fixture.Build<RegisterUserModel>()
                        .With(x => x.Email=="Karthik@ea.com").Create();


            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys(model.Name);
            driver.FindElement(By.Id("Password")).SendKeys(model.Password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(model.Password);
            driver.FindElement(By.Id("Email")).SendKeys(model.Email);

            //Autofixtures other options


            
        }
    }
}
