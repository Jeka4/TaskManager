using System.Windows;
using TaskManager.Views;
using TaskManager.DataModels;
using TaskManager.Presenters;
using TaskManager.PresenterComponents;
using TaskManager.DataModelComponents;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            IDateConverter dateConverter = new DateConverter("dd.MM.yyyy");
            IPriorityConverter priorityConverter = new PriorityConverter();
            ITaskFilter taskFilter = new TasksFilter();

            IMainWindow mainWindow = new MainWindow();
            IDataModel dataModel = new DataModel(taskFilter);
            ITaskManagerPresenter taskManagerPresenter = new TaskManagerPresenter(mainWindow, dataModel, dateConverter, priorityConverter);
        }
    }
}
