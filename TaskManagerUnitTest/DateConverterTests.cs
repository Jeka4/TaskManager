using System;
using NUnit.Framework;
using TaskManager.PresenterComponents;

namespace TaskManagerUnitTest
{
    [TestFixture]
    public class DateConverterTests
    {
        [Test]
        public void FormatStringIsNull()
        {
            string formatString = null;

            Assert.Throws<ArgumentException>(() =>
                new DateConverter(formatString)
            );
        }
    }
}
