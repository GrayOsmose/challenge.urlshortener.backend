using System;
using System.Linq;
using urlshortener.web.Controllers;
using Xunit;

namespace urlshortener.web.tests
{
    public class RerouteControllerTest
    {
        private readonly RerouteController _controller;

        public RerouteControllerTest()
        {
            // ToDo : find moq for core 1.1
            // _controller = new RerouteController()
        }

        [Fact]
        public void InGetWithKeyValidationPass()
        {
            // Check key validation
            // method should be called
        }

        [Fact]
        public void InGetWithKeyValidationFail()
        {
            // Check key validation, should be invalid
            // method shouldn't be called
        }

        [Fact]
        public void InGetModelFromManagerPass()
        {
            // Check url model returned
            // method should be called
        }

        [Fact]
        public void InGetModelFromManagerFailModel()
        {
            // Check url model returned, should be null and throw exceptiopn
            // method shouldn't be called
        }
    }
}
