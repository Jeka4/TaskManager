using System.Windows;

namespace TaskManagerView.Views
{
    /// <summary>
    /// Логика взаимодействия для ThirdWindow.xaml
    /// </summary>
    public partial class TasksManagerWindow : Window, ITasksManagerWindow
    {
        public TasksManagerWindow()
        {
            InitializeComponent();
        }
    }
}
