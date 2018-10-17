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
using TaskManager.Components;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            IMainWindow mainWindow = new MainWindow();
            IDataModel dataModel = new DataModel();
            IDateConverter dateConverter = new DateConverter("dd.MM.yyyy");
            
            ITaskManagerPresenter taskManagerPresenter = new TaskManagerPresenter(mainWindow, dataModel, dateConverter);
        }
    }
}
