using System;
using System.Collections.Generic;
using System.Windows;
using TaskManagerView.Components;

namespace TaskManagerView
{
    /// <summary>
    /// Логика взаимодействия для ThirdWindow.xaml
    /// </summary>
    public partial class TasksManagerWindow : Window, ITasksManagerWindow
    {
        public event EventHandler TasksListNeedUpdate = delegate { };

        public TasksManagerWindow()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            TasksListNeedUpdate(this, EventArgs.Empty);

            Show();
        }

        public void SetUserTasksToTasksList(List<UserTaskView> tasks)
        {
            TaskList.ItemsSource = tasks;
        }
    }
}
