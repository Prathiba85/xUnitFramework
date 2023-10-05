using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Abstractions;

namespace XUnitDemo
{
    public class SeleniumWithoutContext
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly ChromeDriver chromeDriver;

        public SeleniumWithoutContext(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            var driver  = new DriverManager().SetUpDriver(new ChromeConfig());
            chromeDriver = new ChromeDriver();    

        }
        [Fact]
        public void Test1( )
        {

            //Console.WriteLine("First test");
            testOutputHelper.WriteLine("First test");
            chromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
            
        }
    }
}