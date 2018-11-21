using System.Windows;
using TaskManagerModel;
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
            IPriorityConverter priorityConverter = new PriorityConverter();
            ITaskFilter taskFilter = new TasksFilter();

            IMainWindow mainWindow = new MainWindow();
            IDataModel dataModel = new DataModel(new UserTasksDbFactory(), taskFilter);
            IPresenter taskManagerPresenter = new Presenter(mainWindow, dataModel, priorityConverter);
        }
    }
}
