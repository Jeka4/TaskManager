using System;

namespace TaskManager.PresenterComponents
{
    public class DateConverter : IDateConverter
    {
        private readonly string _dateFormat;

        /// <summary>
        /// Конструктор DateConverter
        /// </summary>
        /// <param name="dateFormat">Шаблон даты</param>
        public DateConverter(string dateFormat)
        {
            if (string.IsNullOrEmpty(_dateFormat))
                throw new ArgumentException("Format string should not be null or empty.");

            _dateFormat = dateFormat;
        }

        /// <summary>
        /// Преобразует строку в DateTime согласно заданному формату
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        public DateTime ParseDateToString(string date)
        {
            if (string.IsNullOrEmpty(date))
                throw new ArgumentException("Date string should not be null or empty.");

            return DateTime.ParseExact(date, _dateFormat, System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Преобразует дату в строку согласно заданному формату
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        public string ConvertDateToString(DateTime date)
        {
            return date.ToString(_dateFormat);
        }
    }
}
