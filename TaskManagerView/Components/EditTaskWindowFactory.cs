namespace TaskManagerView.Components
{
    internal class EditTaskWindowFactory
    {
        public bool? ShowEditTaskDialogWindow(UserTaskView task)
        {
            IEditTaskWindow editTaskWindow = new EditTaskWindow(task);

            return editTaskWindow.ShowDialog();
        }
    }
}
