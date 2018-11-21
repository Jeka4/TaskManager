using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManagerCommon.Components;
using TaskManagerView.Components;

namespace TaskManagerView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public bool TaskSelected => TaskList.SelectedItem != null;

        public DateInterval DateIntervalSelected { get; private set; }

        public ITaskListSettings TaskListSettings { get; }

        public event EventHandler<UserTaskEventArgs> UserTaskUpdated = delegate { };

        public event EventHandler<UserTaskEventArgs> UserTaskAdded = delegate { };

        public event EventHandler<UserTaskEventArgs> UserTaskDeleted = delegate { };

        public event EventHandler<TaskDateIntervalEventArg> CurrentCalendarDateChanged = delegate { };

        public event EventHandler<FilterEventArgs> FilterTypeChanged = delegate { };

        public event EventHandler<SortEventArgs> SortTypeChanged = delegate { };
        
        public event EventHandler SelectionListUpdated = delegate { };

        public MainWindow()
        {
            TaskListSettings = new TaskListSettings(FilterType.All, SortType.DescendingPriority);
            DateIntervalSelected = new DateInterval(DateTime.Today);
            DataContext = TaskListSettings;

            InitializeComponent();
        }

        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message, "TaskManager", MessageBoxButton.OK);
        }

        public void SetUserTasksToTasksList(List<UserTaskView> tasks)
        {
            TaskList.ItemsSource = tasks;
        }

        public void SetHighlightDates(List<DateTime> dates) //Оптимизировать добавление (месяц; при добавлении\изменении\удалении)
        {
            Style style = new Style(typeof(System.Windows.Controls.Primitives.CalendarDayButton));

            dates = dates.GroupBy(d => d.Date).Select(d => d.Key).ToList();

            foreach (var date in dates)
            {
                DataTrigger dataTrigger = new DataTrigger
                {
                    Binding = new System.Windows.Data.Binding("Date"),
                    Value = date
                };

                dataTrigger.Setters.Add(new Setter(BackgroundProperty, System.Windows.Media.Brushes.AntiqueWhite));
                style.Triggers.Add(dataTrigger);
            }

            Calendar.CalendarDayButtonStyle = style;
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
                DateTime firstDate = ((DateTime)selectedDates[0]).Date;
                DateTime lastDate = ((DateTime)selectedDates[selectedDates.Count - 1]).Date;

                if(firstDate > lastDate)
                {
                    DateTime swapDate = firstDate;
                    firstDate = lastDate;
                    lastDate = swapDate;
                }

                DateIntervalSelected = new DateInterval(firstDate, lastDate);
                CurrentCalendarDateChanged(sender, new TaskDateIntervalEventArg(DateIntervalSelected));
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var task = new UserTaskView
            {
                Priority = TaskPriority.Low,
                TaskDate = (Calendar.SelectedDate != null && Calendar.SelectedDates.Count == 1) ? Calendar.SelectedDate.Value : DateTime.Today,
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

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortTypeChanged(sender, new SortEventArgs(TaskListSettings.Sort));
        }
    }
}
