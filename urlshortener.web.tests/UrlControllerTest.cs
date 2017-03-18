using System;
using System.Linq;
using urlshortener.web.Controllers;
using Xunit;

namespace urlshortener.web.tests
{
    public class UrlControllerTest
    {
        private readonly UrlController _controller;

        public UrlControllerTest()
        {
            // ToDo : find moq for core 1.1
            // _controller = new UrlController()
        }

        [Fact]
        public void InPostWithModelValidationPass()
        {
            // Check url model validation
            // method should be called
        }

        [Fact]
        public void InPostWithModelValidationFailUrl()
        {
            // Check url model validation, should be invalid
            // method shouldn't be called
        }

        [Fact]
        public void InDeleteWithKeyValidationPass()
        {
            // Check key validation
            // method should be called
        }

        [Fact]
        public void InDeleteWithValidationFail()
        {
            // Check key validation
            // method shouldn't be called
        }
    }
}
