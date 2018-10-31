using System.Windows;
using TaskManager.Views;
using TaskManager.DataModels;
using TaskManager.Presenters;
using TaskManager.PresenterComponents;
using TaskManager.DataModelComponents;
using System.Configuration;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string dateFormat = ConfigurationManager.AppSettings["DateFormat"];

            IDateConverter dateConverter = new DateConverter(dateFormat);
            IPriorityConverter priorityConverter = new PriorityConverter();
            ITaskFilter taskFilter = new TasksFilter();

            IMainWindow mainWindow = new MainWindow();
            IDataModel dataModel = new DataModel(taskFilter);
            ITaskManagerPresenter taskManagerPresenter = new TaskManagerPresenter(mainWindow, dataModel, dateConverter, priorityConverter);
        }
    }
}
