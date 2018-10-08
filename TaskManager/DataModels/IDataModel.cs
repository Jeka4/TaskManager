using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace TaskManager
{
    public interface IDataModel
    {
        List<UserTask> GetAllTasks();
        List<UserTask> GetTasksOfDay(DateTime date);
    }
}
