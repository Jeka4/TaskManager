using NUnit.Framework;
using TaskManagerModel;
using TaskManagerPresenter.Components;
using TaskManagerUnitTest.Fakes;
using TaskManagerView.Components;

namespace TaskManagerUnitTest
{
    [TestFixture]
    class TasksControlPresenterTests
    {
        private readonly ITaskManagerWindowFactory _window = new TaskManagerWindowFactoryFake();
        private readonly IDataModel _dataModel = new DataModelFake();
        private readonly IPriorityConverter _priorityConverter = new PriorityConverterStub();

    }
}
