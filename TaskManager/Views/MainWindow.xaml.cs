using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManager.ViewComponents;
using TaskManager.Components;

namespace TaskManager.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public bool TaskSelected => TaskList.SelectedItem != null;

        public DateInterval DateIntervalSelected { get; private set; }

        public ITaskListSettings TaskListSettings { get; private set; }

        public event EventHandler<UserTaskEventArgs> UserTaskUpdated = delegate { };

        public event EventHandler<UserTaskEventArgs> UserTaskAdded = delegate { };

        public event EventHandler<UserTaskEventArgs> UserTaskDeleted = delegate { };

        public event EventHandler<TaskDateIntervalEventArg> CurrentCalendarDateChanged = delegate { };

        public event EventHandler<FilterEventArgs> FilterTypeChanged = delegate { };

        public event EventHandler SelectionListUpdated = delegate { };

        public MainWindow()
        {
            TaskListSettings = new TaskListSettings(FilterType.All);
            DateIntervalSelected = new DateInterval(DateTime.Now);
            DataContext = TaskListSettings;

            InitializeComponent();
        }

        public void SetUserTasksToTasksList(List<UserTaskView> tasks)
        {
            TaskList.ItemsSource = tasks;
        }

        public void EnableEditRemoveControls(bool enable)
        {
            buttonEdit.IsEnabled = enable;
            buttonDelete.IsEnabled = enable;
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionListUpdated(sender, new EventArgs());
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e) //Использовать e?
        {
            var selectedDates = e.AddedItems;

            if (selectedDates.Count > 0)
            {
                DateTime beginDate = (DateTime)selectedDates[0];
                DateTime endDate = (DateTime)selectedDates[selectedDates.Count - 1];

                DateIntervalSelected = new DateInterval(beginDate, endDate);
                CurrentCalendarDateChanged(sender, new TaskDateIntervalEventArg(DateIntervalSelected));
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            UserTaskView task = new UserTaskView()
            {
                Priority = TaskPriority.Low,
                TaskDate = DateTime.Now,
                NotifyDate = DateTime.Now
            };

            IEditTaskWindow editTaskWindow = new EditTaskWindow(task);
            bool? dialogResult = editTaskWindow.ShowDialog();

            if (dialogResult == true)
            {
                UserTaskAdded(sender, new UserTaskEventArgs(task));
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TaskSelected == false)
                return;

            UserTaskView task = TaskList.SelectedItem as UserTaskView;

            if (task == null)
                return;

            IEditTaskWindow editTaskWindow = new EditTaskWindow(task);
            bool? dialogResult = editTaskWindow.ShowDialog();

            if (dialogResult == true)
            {
                UserTaskUpdated(sender, new UserTaskEventArgs(task));
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TaskSelected == false)
                return;

            UserTaskView task = TaskList.SelectedItem as UserTaskView;

            if (task == null)
                return;

            UserTaskDeleted(sender, new UserTaskEventArgs(task));
        }

        private void ButtonControl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Calendar_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender != null && Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem)
                Mouse.Capture(null);
        }

        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterTypeChanged(sender, new FilterEventArgs(TaskListSettings.Filter));
        }
    }
}
