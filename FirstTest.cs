using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace XUnitDemo
{
    public class FirstTest
    {

        private readonly ITestOutputHelper testoutputHelper;
     

       public FirstTest(ITestOutputHelper testoutputHelper)
        {
            this.testoutputHelper = testoutputHelper;
        }
        [Fact]      
        public void Test1()
        {
           // Console.WriteLine("First test");
            testoutputHelper.WriteLine("First Test");
        }
    }
}
