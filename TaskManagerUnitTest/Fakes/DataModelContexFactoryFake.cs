using System.Collections.Generic;
using TaskManagerModel;
using TaskManagerModel.Components;

namespace TaskManagerUnitTest.Fakes
{
    class DataModelContexFactoryFake : IContextFactory
    {
        private readonly List<UserTask> _data;

        public DataModelContexFactoryFake(List<UserTask> data)
        {
            _data = data;
        }

        public IContext BuildContex()
        {
            return new DataModelContexFake(_data);
        }
    }
}
