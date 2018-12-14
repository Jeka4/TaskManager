using TaskManagerView;
using TaskManagerView.Components;

namespace TaskManagerUnitTest.Fakes
{
    class TaskManagerWindowFactoryFake : ITaskManagerWindowFactory
    {
        public ITasksManagerWindow ShowTaskManagerWindow()
        {
            return null;
        }
    }
}
