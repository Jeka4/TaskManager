using System;
using NUnit.Framework;
using TaskManagerPresenter.PresenterComponents;

namespace TaskManagerUnitTest
{
    [TestFixture]
    public class DateConverterTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void FormatStringIsNullOrEmpty(string formatString)
        {
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
