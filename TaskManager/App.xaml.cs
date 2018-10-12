using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskManager.Views;
using TaskManager.DataModels;
using TaskManager.Presenters;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            IEditTaskWindow editTaskWindow = new EditTaskWindow();
            ITasksManagerWindow tasksManagerWindow = new TasksManagerWindow();
            IMainWindow mainWindow = new MainWindow(editTaskWindow, tasksManagerWindow);

            IDataModel dataModel = new DataModel();
            
            ITaskManagerPresenter taskManagerPresenter = new TaskManagerPresenter(mainWindow, dataModel);
        }
    }
}
