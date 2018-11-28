using System.Windows;
using System.Windows.Controls;
using TaskManagerView.Components;

namespace TaskManagerView
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
            if (Validation.GetHasError(textboxName) ||
                Validation.GetHasError(textboxDescription) ||
                Validation.GetHasError(comboboxPriority) ||
                Validation.GetHasError(datapickerTaskDate) ||
                Validation.GetHasError(datapickerNotifyDate))
            {
                MessageBox.Show("Допущена ошибка при заполении полей!");
                return;
            }

            DialogResult = true;
        }
    }
}
