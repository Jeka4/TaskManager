﻿using System.Collections.Generic;
using TaskManagerModel;
using TaskManagerModel.Components;

namespace TaskManagerUnitTest.Fakes
{
    class DataModelFactoryFake : IContextFactory
    {
        private List<UserTask> _data;

        public DataModelFactoryFake(List<UserTask> data)
        {
            _data = data;
        }

        public IContext BuildContex()
        {
            return new DataModelContexFake(_data);
        }
    }
}
