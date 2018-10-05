using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public interface ITaskManagerPresenter //Заглушки
    {
        void AddTask(UserTask task);
        void RemoveTask(int id);
        void EditTask(UserTask task);
        List<UserTask> LoadTasksOfDay(DateTime day);
        List<UserTask> LoadAllTasks();
        void SortBy(SortType sort); //Перечисление
        void FilterBy(FilterType filter); //Переичсление
    }
}
