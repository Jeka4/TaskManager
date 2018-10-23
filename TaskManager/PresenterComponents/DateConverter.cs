using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.PresenterComponents
{
    public class DateConverter : IDateConverter
    {
        private readonly string _dataFormat;

        /// <summary>
        /// Конструктор DateConverter
        /// </summary>
        /// <param name="dataFormat">Шаблон даты</param>
        public DateConverter(string dataFormat)
        {
            if (_dataFormat == string.Empty)
                throw new ArgumentException("Format string should not be empty.");

            _dataFormat = dataFormat;
        }

        /// <summary>
        /// Преобразует строку в DateTime согласно заданному формату
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        public DateTime ParseDateToString(string date)
        {
            if (date == string.Empty)
                throw new ArgumentException("Date string should not be empty.");

            return DateTime.ParseExact(date, _dataFormat, System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Преобразует дату в строку согласно заданному формату
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        public string ConvertDateToString(DateTime date)
        {
            return date.ToString(_dataFormat);
        }
    }
}
