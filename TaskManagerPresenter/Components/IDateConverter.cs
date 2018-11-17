using System;

namespace TaskManagerPresenter.Components
{
    public interface IDateConverter
    {
        DateTime ParseStringToDate(string date);
        string ConvertDateToString(DateTime date);
    }
}
