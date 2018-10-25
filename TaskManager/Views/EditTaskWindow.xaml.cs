using System.Windows;
using TaskManager.ViewComponents;

namespace TaskManager.Views
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class EditTaskWindow : Window, IEditTaskWindow
    {
        public EditTaskWindow(UserTaskView task)
        {
            InitializeComponent();

            grid.DataContext = task;
        }

        private void buttonAdd2_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
