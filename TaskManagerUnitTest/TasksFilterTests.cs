using System;
using NUnit.Framework;
using TaskManager.DataModelComponents;
using System.Collections.Generic;
using TaskManager.DataModels;
using TaskManager.Components;
using System.Linq;

namespace TaskManagerUnitTest
{
    [TestFixture]
    public class TasksFilterTests
    {
        private List<UserTask> GenerateUserTaskList()
        {
            return new List<UserTask>
            {
                new UserTask { Priority = TaskPriority.High.ToString() },
                new UserTask { Priority = TaskPriority.Medium.ToString() },
                new UserTask { Priority = TaskPriority.Low.ToString() }
            };
        }

        [Test]
        public void FilterHighPriority()
        {
            var filter = new TasksFilter();
            var usertasks = GenerateUserTaskList();

            var result = filter.Filter(usertasks.AsQueryable(), FilterType.HighPriority);

            Assert.IsTrue(result.All(t => t.Priority == TaskPriority.High.ToString()));
        }
    }
}
