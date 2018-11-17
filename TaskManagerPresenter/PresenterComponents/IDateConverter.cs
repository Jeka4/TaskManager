using System;

namespace TaskManagerPresenter.PresenterComponents
{
    public interface IDateConverter
    {
        DateTime ParseStringToDate(string date);
        string ConvertDateToString(DateTime date);
    }
}
