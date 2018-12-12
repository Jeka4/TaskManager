﻿using System;
using System.Windows;
using TaskManagerCommon.Components;
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
            ITasksControlPresenter tasksControlPresenter = new TasksControlPresenter(new TaskManagerWindowFactory(), dataModel, priorityConverter);

            new PresenterSubscriber(taskManagerPresenter, tasksControlPresenter, dataModel, mainWindow);

            taskManagerPresenter.Initialize();

            
/*            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                taskManagerPresenter.AddTask(new UserTaskView
                {
                    Name = rnd.Next(0, 1000).ToString(),
                    Description = rnd.Next(0, 1000).ToString(),
                    IsNotified = false,
                    Priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), rnd.Next(1, 3).ToString()),
                    TaskDate = DateTime.Today,
                    NotifyDate = DateTime.Today
                });
            }*/
        }

        class PresenterSubscriber
        {
            private readonly IPresenter _presenter;
            private readonly IMainWindow _mainWindow;
            private readonly ITasksControlPresenter _tasksControlPresenter;

            public PresenterSubscriber(IPresenter presenter, ITasksControlPresenter tasksControlPresenter, IDataModel dataModel, IMainWindow mainWindow)
            {
                _presenter = presenter;
                _mainWindow = mainWindow;
                _tasksControlPresenter = tasksControlPresenter;

                dataModel.TasksDbUpdated += DataModel_TasksDBUpdated;

                _mainWindow.CurrentCalendarDateChanged += MainWindowOnCurrentCalendarDateChanged;
                _mainWindow.SelectionListUpdated += MainWindowOnSelectionListUpdated;
                _mainWindow.UserTaskAdded += MainWindowOnUserTaskAdded;
                _mainWindow.UserTaskUpdated += MainWindowOnUserTaskUpdated;
                _mainWindow.UserTaskDeleted += MainWindowOnUserTaskDeleted;
                _mainWindow.FilterTypeChanged += MainWindowOnFilterTypeChanged;
                _mainWindow.SortTypeChanged += MainWindowOnSortTypeChanged;
                _mainWindow.TasksListNeedUpdate += MainWindowOnTasksListNeedUpdate;
                _mainWindow.HighlightListNeedUpdate += MainWindowOnHighlightListNeedUpdate;
                _mainWindow.TasksControlButtonPressed += MainWindowOnTasksControlButtonPressed;

                _tasksControlPresenter.UserTaskUpdated += TasksControlPresenterOnUserTaskUpdated;
            }

            private void TasksControlPresenterOnUserTaskUpdated(object sender, UserTaskEventArgs e)
            {
                _presenter.EditTask(e?.UserTaskView);
            }

            private void MainWindowOnTasksControlButtonPressed(object sender, EventArgs eventArgs)
            {
                _tasksControlPresenter.ShowTasksControlWindow();
            }

            private void MainWindowOnHighlightListNeedUpdate(object sender, EventArgs eventArgs)
            {
                _presenter.RefreshViewHighlightList();
            }

            private void MainWindowOnTasksListNeedUpdate(object sender, EventArgs eventArgs)
            {
                _presenter.RefreshViewTasksList(_mainWindow.DateIntervalSelected);
            }

            private void MainWindowOnSortTypeChanged(object sender, SortEventArgs e)
            {
                _presenter.SortTypeChange(e?.Sort ?? SortType.Undefined);
            }

            private void MainWindowOnFilterTypeChanged(object sender, FilterEventArgs e)
            {
                _presenter.FilterTypeChange(e?.Filter ?? FilterType.Undefined);
            }

            private void MainWindowOnUserTaskDeleted(object sender, UserTaskEventArgs e)
            {
                _presenter.RemoveTask(e.UserTaskView);
            }

            private void MainWindowOnUserTaskUpdated(object sender, UserTaskEventArgs e)
            {
                _presenter.EditTask(e.UserTaskView);
            }

            private void MainWindowOnUserTaskAdded(object sender, UserTaskEventArgs e)
            {
                _presenter.AddTask(e.UserTaskView);
            }

            private void MainWindowOnSelectionListUpdated(object sender, EventArgs e)
            {
                _presenter.SelectionListUpdated();
            }

            private void DataModel_TasksDBUpdated(object sender, EventArgs e)
            {
                _presenter.RefreshViewTasksList(_mainWindow.DateIntervalSelected);
                _presenter.RefreshViewHighlightList();
                _tasksControlPresenter.RefreshTasksList();
            }

            private void MainWindowOnCurrentCalendarDateChanged(object sender, TaskDateIntervalEventArg e)
            {
                _presenter.RefreshViewTasksList(e?.DateInterval ?? new DateInterval());
            }
        }
    }
}
