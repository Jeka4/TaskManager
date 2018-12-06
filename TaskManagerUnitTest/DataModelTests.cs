﻿using NUnit.Framework;
using TaskManagerModel.Components;
using TaskManagerModel;
using TaskManagerCommon.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using TaskManagerUnitTest.Fakes;

namespace TaskManagerUnitTest
{
    [TestFixture]
    class DataModelTests
    {

        [Test]
        public void InsertCorrectTask()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var task = new UserTask
            {
                Name = "TestName",
                Description = "TestDescription",
                Priority = (long)TaskPriority.Medium,
                IsNotified = false
            };

            Assert.DoesNotThrow(() => dataModel.AddTask(task));
        }

        [TestCase("", "TaskDescription", TaskPriority.Medium, Description = "Empty name")]
        [TestCase(null, "TaskDescription", TaskPriority.Medium, Description = "Null name")]
        [TestCase("Task", "", TaskPriority.Medium, Description = "Empty description")]
        [TestCase("Task", null, TaskPriority.Medium, Description = "Null description")]
        [TestCase("Task", "TaskDescription", TaskPriority.Undefined, Description = "Priority undefined")]
        public void InsertInvalidTask(string name, string descr, TaskPriority prior)
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var task = new UserTask
            {
                Name = name,
                Description = descr,
                Priority = (long)prior,
                IsNotified = false
            };

            Assert.Throws<ValidationException>(() => dataModel.AddTask(task));
        }

        [Test]
        public void InsertNullTask()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            Assert.Throws<ArgumentNullException>(() => dataModel.AddTask(null));
        }

        [Test]
        public void UpdateCorrectTask()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var task = new UserTask
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Priority = (long)TaskPriority.Medium,
                IsNotified = false
            };

            Assert.DoesNotThrow(() => dataModel.UpdateTask(task));
        }

        [TestCase(-1, "Task", "TaskDescription", TaskPriority.Medium, Description = "Invalid id < 0")]
        [TestCase(0, "Task", "TaskDescription", TaskPriority.Medium, Description = "Invalid id = 0")]
        [TestCase(1, "", "TaskDescription", TaskPriority.Medium, Description = "Empty name")]
        [TestCase(1, null, "TaskDescription", TaskPriority.Medium, Description = "Null name")]
        [TestCase(1, "Task", "", TaskPriority.Medium, Description = "Empty description")]
        [TestCase(1, "Task", null, TaskPriority.Medium, Description = "Null description")]
        [TestCase(1, "Task", "TaskDescription", TaskPriority.Undefined, Description = "Priority undefined")]
        public void UpdateInvalidTask(long id, string name, string descr, TaskPriority prior)
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var task = new UserTask
            {
                Id = id,
                Name = name,
                Description = descr,
                Priority = (long)prior,
                IsNotified = false
            };

            Assert.Throws<ValidationException>(() => dataModel.UpdateTask(task));
        }

        [Test]
        public void UpdateNullTask()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            Assert.Throws<ArgumentNullException>(() => dataModel.UpdateTask(null));
        }

        [Test]
        public void DeleteCorrectTask()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var task = new UserTask
            {
                Id = 1
            };

            Assert.DoesNotThrow(() => dataModel.DeleteTask(task));
        }

        [TestCase(-1, Description = "Invalid id = -1 < 0")]
        [TestCase(0, Description = "Invalid id = 0")]
        public void DeleteInvalidTask(long id)
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var task = new UserTask
            {
                Id = id
            };

            Assert.Throws<ValidationException>(() => dataModel.DeleteTask(task));
        }

        [Test]
        public void DeleteNullTask()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            Assert.Throws<ArgumentNullException>(() => dataModel.DeleteTask(null));
        }

        [Test]
        public void DeleteCorrectTasks()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var tasks = new List<UserTask>
            {
                new UserTask { Id = 1 },
                new UserTask { Id = 2 },
                new UserTask { Id = 3 }
            };

            Assert.DoesNotThrow(() => dataModel.DeleteTasks(tasks));
        }

        [Test]
        public void DeleteInvalidIdTasks()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var tasks = new List<UserTask>
            {
                new UserTask { Id = -1 },
                new UserTask { Id = -2 },
                new UserTask { Id = -3 }
            };

            Assert.Throws<ValidationException>(() => dataModel.DeleteTasks(tasks));
        }

        [Test]
        public void DeleteNullListTasks()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            Assert.Throws<ArgumentNullException>(() => dataModel.DeleteTasks(null));
        }

        [Test]
        public void DeleteListTasksOfNulls()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(new List<UserTask>());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var tasks = new List<UserTask>
            {
                null,
                null,
                null
            };

            Assert.Throws<ArgumentException>(() => dataModel.DeleteTasks(tasks));
        }

        [Test]
        public void GetAllTasks()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(GenerateUserTaskList());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var tasks = dataModel.GetAllTasks();

            Assert.AreEqual(GenerateUserTaskList().Count, tasks.Count);
        }

        [Test, TestCaseSource(typeof(DatesForTest), nameof(DatesForTest.TestCase))]
        public void GetTasksOfDay(DateTime date)
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(GenerateUserTaskList());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var tasks = dataModel.GetTasksOfDay(date);

            Assert.AreEqual(date, tasks.Single().TaskDate);
        }

        [Test]
        public void GetTasksOfTwoDays()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(GenerateUserTaskList());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var tasks = dataModel.GetTasksOfDays(new DateTime(1, 1, 1), new DateTime(1, 1, 2));

            Assert.True(tasks.Count == 2 && tasks[0].TaskDate.Day < 3 && tasks[1].TaskDate.Day < 3);
        }

        [Test]
        public void GetTasksOfTwoDaysRevert()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(GenerateUserTaskList());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            Assert.Throws<ArgumentException>(
                () => dataModel.GetTasksOfDays(new DateTime(1, 1, 2), new DateTime(1, 1, 1)));
        }

        [Test]
        public void GetAllTasksDates()
        {
            IContextFactory contexFactoryFake = new DataModelFactoryFake(GenerateUserTaskList());
            IDataModel dataModel = new DataModel(contexFactoryFake, new TasksFilterFake());

            var dates = dataModel.GetAllTaskDates();

            Assert.AreEqual(3, dates.Count);
        }

        private List<UserTask> GenerateUserTaskList()
        {
            return new List<UserTask>
            {
                new UserTask
                {
                    Name = "TestName1",
                    Description = "TestDescription1",
                    Priority = (long)TaskPriority.Low,
                    IsNotified = false,
                    TaskDate = new DateTime(1, 1, 1),
                    NotifyDate = new DateTime(1, 1, 1)
                },
                new UserTask
                {
                    Name = "TestName2",
                    Description = "TestDescription2",
                    Priority = (long)TaskPriority.Medium,
                    IsNotified = true,
                    TaskDate = new DateTime(1, 1, 2),
                    NotifyDate = new DateTime(1, 1, 2)
                },
                new UserTask
                {
                    Name = "TestName3",
                    Description = "TestDescription3",
                    Priority = (long)TaskPriority.High,
                    IsNotified = true,
                    TaskDate = new DateTime(1, 1, 3),
                    NotifyDate = new DateTime(1, 1, 3)
                },
            };
        }

        private class DatesForTest
        {
            public static IEnumerable TestCase
            {
                get
                {
                    yield return new TestCaseData(new DateTime(1, 1, 1));
                    yield return new TestCaseData(new DateTime(1, 1, 2));
                    yield return new TestCaseData(new DateTime(1, 1, 3));
                }
            } 
        }
    }
}
