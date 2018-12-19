namespace TaskManagerView.Components
{
    internal class EditTaskWindowFactory
    {
        public bool? ShowEditTaskDialogWindow(UserTaskView task, EditWindowMode mode)
        {
            IEditTaskWindow editTaskWindow = new EditTaskWindow(task, mode);

            return editTaskWindow.ShowDialog();
        }
    }
}
