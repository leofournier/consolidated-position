using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consolidated.Position.Test
{
    [TestClass]
    public class InitializeTest
    {
        public IConfiguration Configuration { get; set; }

        public ILoggerFactory LoggerFactory { get; set; }

        [TestInitialize]
        public void Init()
        {
            var configTest = new ConfigurationTest();
            Configuration = configTest.LoadConfiguration();
            LoggerFactory = configTest.LoggerFactoryConfiguration();
        }

        [TestMethod]
        public void DeveValidarLoadConfiguration() => Assert.IsNotNull(Configuration);

        [TestMethod]
        public void DeveValidarLoggerFactoryConfiguration() => Assert.IsNotNull(LoggerFactory);
    }
}
