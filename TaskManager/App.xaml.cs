using System.Windows;
using TaskManagerView.Views;
using TaskManagerModel.DataModels;
using TaskManagerPresenter.Presenters;
using TaskManagerPresenter.PresenterComponents;
using System.Configuration;
using TaskManagerModel.DataModelComponents;

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
            ITaskManagerPresenter taskManagerPresenter = new Presenter(mainWindow, dataModel, dateConverter, priorityConverter);
        }
    }
}
