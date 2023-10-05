using AutoFixture;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitDemo.Attribute
{
    public class RegisterUserAttribute : AutoDataAttribute
    {
        public RegisterUserAttribute() : base(
            ()=>
                { 
            var fixture = new Fixture();
            fixture.Customize<RegisterUserModel>(x =>
            x
                .With(Xunit => Xunit.Email, "karthick@techgreek.com")
                .With(Xunit => Xunit.Password, "Password@123"));
                    return fixture;
        })
        { }
    }
    
    
}
