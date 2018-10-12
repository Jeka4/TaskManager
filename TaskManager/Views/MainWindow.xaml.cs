using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Presenters;

namespace TaskManager.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public bool TaskSelected { get; private set; }

        public event EventHandler<UserTaskEventArgs> UserTaskUpdated = delegate { };

        public event EventHandler<TaskDateEventArg> CurrentCalendarDateChanged = delegate { };

        public event EventHandler SelectionListUpdated = delegate { };

        private IEditTaskWindow _editTaskWindow;

        private ITasksManagerWindow _tasksManagerWindow;

        public MainWindow(IEditTaskWindow editTaskWindow, ITasksManagerWindow tasksManagerWindow)
        {
            _editTaskWindow = editTaskWindow;
            _tasksManagerWindow = tasksManagerWindow;
            
            InitializeComponent();
        }

        public void SetUserTasksToTasksList(List<UserTaskView> tasks)
        {
            TaskList.ItemsSource = tasks;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;

            if(calendar != null && calendar.SelectedDate.HasValue)
                CurrentCalendarDateChanged(this, new TaskDateEventArg(calendar.SelectedDate.Value));
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonControl_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
