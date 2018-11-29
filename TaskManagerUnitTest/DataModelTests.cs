using NUnit.Framework;
using TaskManagerModel.Components;
using TaskManagerModel;
using TaskManagerCommon.Components;
using System;

namespace TaskManagerUnitTest
{
    [TestFixture]
    class DataModelTests
    {
        private readonly IContextFactory _contexFactory;

        public DataModelTests()
        {
            _contexFactory = new DataModelTestFactory();
        }

        [Test]
        public void InsertTaskIntoModel()
        {
            using (var contex = _contexFactory.BuildContex())
            {
                contex.Insert(new UserTask
                {
                    Name = "TestName",
                    Description = "TestDescription",
                    Priority = (long)TaskPriority.Medium,
                    IsNotified = false,
                    TaskDate = DateTime.Today,
                    NotifyDate = DateTime.Today
                });
            }
        }
    }
}
