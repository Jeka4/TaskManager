using System.Windows;
using TaskManagerModel;
using System.Configuration;
using TaskManagerModel.Components;
using TaskManagerPresenter;
using TaskManagerPresenter.Components;
using TaskManagerView;

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
            IPresenter taskManagerPresenter = new Presenter(mainWindow, dataModel, dateConverter, priorityConverter);
        }
    }
}
