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

        [Test]
        public void FormatStringIsEmpty()
        {
            string formatString = string.Empty;

            Assert.Throws<ArgumentException>(() =>
                new DateConverter(formatString)
            );
        }

        [Test]
        public void ParseDateWithNullString()
        {
            string dateString = null;
            IDateConverter dateConverter = new DateConverter("dd.MM.yyyy");

            Assert.Throws<ArgumentException>(() =>
                dateConverter.ParseStringToDate(dateString)
            );
        }
    }
}
