using AutoFixture;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace XUnitDemo
{
    public class RegisterUserModel
    {
        public string Name { get; set; }
        public string Password {get;set;}
        public string CPassword { get; set; }
        public string Email { get; set; }

        

    }
}
