using System;

namespace TaskManager.PresenterComponents
{
    public interface IDateConverter
    {
        DateTime ParseStringToDate(string date);
        string ConvertDateToString(DateTime date);
    }
}
