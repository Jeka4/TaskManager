using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            EditTaskWindow editTaskWindow = new EditTaskWindow();
            TasksManagerWindow tasksManagerWindow = new TasksManagerWindow();
            IMainWindow mainWindow = new MainWindow(editTaskWindow, tasksManagerWindow);

            IDataModel dataModel = new DataModel();
            
            ITaskManagerPresenter taskManagerPresenter = new TaskManagerPresenter(mainWindow, dataModel);
        }
    }
}
