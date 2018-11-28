using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManagerView.Components;

namespace TaskManagerView
{
    /// <summary>
    /// Логика взаимодействия для ThirdWindow.xaml
    /// </summary>
    public partial class TasksManagerWindow : Window, ITasksManagerWindow
    {
        public bool IsTaskSelected => TaskList.SelectedItem != null;

        public event EventHandler<UserTaskView> UserTaskEdited = delegate { };

        public event EventHandler<UserTasksListEventArgs> UserTasksDeleted = delegate { };

        public event EventHandler TasksListNeedUpdate = delegate { };

        public event EventHandler SelectionListChanged = delegate { };

        private readonly EditTaskWindowFactory _editTaskWindowFactory;

        public TasksManagerWindow()
        {
            _editTaskWindowFactory = new EditTaskWindowFactory();

            InitializeComponent();
        }

        public void Initialize()
        {
            TasksListNeedUpdate(this, EventArgs.Empty);

            Show();
        }

        public void EnableDeleteButton(bool enable)
        {
            buttonDelete2.IsEnabled = enable;
        }

        public void SetUserTasksToTasksList(List<UserTaskView> tasks)
        {
            TaskList.ItemsSource = tasks;
        }
        private void ListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionListChanged(sender, EventArgs.Empty);
        }

        private void ListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (IsTaskSelected == false)
                return;

            UserTaskView task = TaskList.SelectedItem as UserTaskView;

            if (task == null)
                return;

            var dialogResult = _editTaskWindowFactory.ShowEditTaskDialogWindow(task);

            if (dialogResult == true)
            {
                //UserTaskUpdated(sender, new UserTaskEventArgs(task)); Продумать!!
            }
        }

    }
}
