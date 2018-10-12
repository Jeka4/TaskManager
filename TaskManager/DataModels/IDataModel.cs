using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace TaskManager.DataModels
{
    public interface IDataModel
    {
        List<UserTask> GetAllTasks();
        List<UserTask> GetTasksOfDay(string date);
        void SortBy(SortType sort); //Перечисление
        void FilterBy(FilterType filter); //Переичсление
    }
}
