using System;

namespace TaskManager.PresenterComponents
{
    public interface IDateConverter
    {
        DateTime ParseDateToString(string date);
        string ConvertDateToString(DateTime date);
    }
}
