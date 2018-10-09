using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public interface ITaskManagerPresenter //Заглушки
    {
        void AddTask(UserTaskView task);
        void RemoveTask(int id);
        void EditTask(UserTaskView task);
        List<UserTaskView> LoadTasksOfDay(DateTime day);
        List<UserTaskView> LoadAllTasks();
    }
}
