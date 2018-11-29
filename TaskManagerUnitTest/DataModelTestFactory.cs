using System;
using TaskManagerModel.Components;

namespace TaskManagerUnitTest
{
    class DataModelTestFactory : IContextFactory
    {
        public IContext BuildContex()
        {
            return new DataModelTestContex();
        }
    }
}
