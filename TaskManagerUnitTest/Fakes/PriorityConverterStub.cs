using TaskManagerCommon.Components;
using TaskManagerPresenter.Components;

namespace TaskManagerUnitTest.Fakes
{
    class PriorityConverterStub : IPriorityConverter
    {
        public long ConvertToModelPriority(TaskPriority priority)
        {
            return 0;
        }

        public TaskPriority ConvertToViewPriority(long priority)
        {
            return TaskPriority.Undefined;
        }
    }
}
