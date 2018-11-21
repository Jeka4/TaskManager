using System;
using System.Windows;
using TaskManagerModel;
using TaskManagerModel.Components;
using TaskManagerPresenter;
using TaskManagerPresenter.Components;
using TaskManagerView;
using TaskManagerView.Components;

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

            new PresenterSubscriber(taskManagerPresenter, dataModel, mainWindow);
        }

        class PresenterSubscriber
        {
            private readonly IPresenter _presenter;
            private readonly IMainWindow _mainWindow;
            private readonly IDataModel _dataModel;

            public PresenterSubscriber(IPresenter presenter, IDataModel dataModel, IMainWindow mainWindow)
            {
                _presenter = presenter;
                _dataModel = dataModel;
                _mainWindow = mainWindow;

                _dataModel.TasksDbUpdated += DataModel_TasksDBUpdated;

                _mainWindow.CurrentCalendarDateChanged += MainWindow_CurrentCalendarDateChanged;
                _mainWindow.SelectionListUpdated += MainWindow_SelectionListUpdated;
                _mainWindow.UserTaskAdded += MainWindow_UserTaskAdded;
                _mainWindow.UserTaskUpdated += MainWindow_UserTaskUpdated;
                _mainWindow.UserTaskDeleted += MainWindow_UserTaskDeleted;
                _mainWindow.FilterTypeChanged += MainWindow_FilterTypeChanged;
                _mainWindow.SortTypeChanged += MainWindowOnSortTypeChanged;
            }


            private void MainWindowOnSortTypeChanged(object sender, SortEventArgs e)
            {
                var sort = e.Sort;

                _dataModel.Sort = sort;
                _presenter.RefreshViewTasksList(_mainWindow.DateIntervalSelected);
            }

            private void MainWindow_FilterTypeChanged(object sender, FilterEventArgs e)
            {
                var filter = e.Filter; //Исключение?

                _dataModel.Filter = filter;
                _presenter.RefreshViewTasksList(_mainWindow.DateIntervalSelected);
            }

            private void MainWindow_UserTaskDeleted(object sender, UserTaskEventArgs e)
            {
                _presenter.RemoveTask(e.UserTaskView);
            }

            private void MainWindow_UserTaskUpdated(object sender, UserTaskEventArgs e)
            {
                _presenter.EditTask(e.UserTaskView);
            }

            private void MainWindow_UserTaskAdded(object sender, UserTaskEventArgs e)
            {
                _presenter.AddTask(e.UserTaskView);
            }

            private void MainWindow_SelectionListUpdated(object sender, EventArgs e)
            {
                _mainWindow.EnableEditRemoveControls(_mainWindow.TaskSelected);
            }

            private void DataModel_TasksDBUpdated(object sender, EventArgs e)
            {
                _presenter.RefreshViewTasksList(_mainWindow.DateIntervalSelected);
            }

            private void MainWindow_CurrentCalendarDateChanged(object sender, TaskDateIntervalEventArg e)
            {
                _presenter.RefreshViewTasksList(_mainWindow.DateIntervalSelected);
            }
        }
    }
}
