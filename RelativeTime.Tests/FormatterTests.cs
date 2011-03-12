using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RelativeTime.Tests
{
    [TestClass]
    public class FormatterTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DeploymentItem(@"RelativeTime.Tests\FormatterTestData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"|DataDirectory|\FormatterTestData.xml", "test", DataAccessMethod.Sequential)]
        public void Formatter_Format_ShouldReturnExpectedValues()
        {
            var timeSpan = TimeSpan.Parse((string)TestContext.DataRow["timeSpan"]);
            var formattedValue = (string)TestContext.DataRow["formattedValue"];

            var actual = new Formatter().Format(timeSpan);

            Assert.AreEqual(formattedValue, actual, "input: " + timeSpan);
        }
    }
}