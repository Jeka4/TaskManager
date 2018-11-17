using System.Windows;
using TaskManagerView.ViewComponents;

namespace TaskManagerView.Views
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class EditTaskWindow : Window, IEditTaskWindow
    {
        public EditTaskWindow(UserTaskView task)
        {
            DataContext = task;

            InitializeComponent();
        }

        private void buttonAdd2_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
