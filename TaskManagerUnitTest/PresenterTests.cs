using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TaskManagerCommon.Components;
using TaskManagerModel;
using TaskManagerPresenter;
using TaskManagerPresenter.Components;
using TaskManagerUnitTest.Fakes;
using TaskManagerView.Components;

namespace TaskManagerUnitTest
{
    [TestFixture]
    class PresenterTests
    {
        [TestCase(SortType.AscendingPriority)]
        [TestCase(SortType.DescendingPriority)]
        public void TestSortTypeChangeCorrect(SortType sort)
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub()); //STUB!!!!!!!

            Assert.DoesNotThrow(() => presenter.SortTypeChange(sort));
        }

        [Test]
        public void TestSortTypeChangeUndefined()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            SortType sort = SortType.Undefined;

            Assert.Throws<ArgumentException>(() => presenter.SortTypeChange(sort));
        }

        [TestCase(FilterType.All)]
        [TestCase(FilterType.HighPriority)]
        [TestCase(FilterType.LowPriority)]
        [TestCase(FilterType.MediumPriority)]
        public void TesttFilterTypeChangeCorrect(FilterType filter)
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            Assert.DoesNotThrow(() => presenter.FilterTypeChange(filter));
        }

        [Test]
        public void TestFilterTypeChangeUndefined()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            FilterType filter = FilterType.Undefined;

            Assert.Throws<ArgumentException>(() => presenter.FilterTypeChange(filter));
        }

        [Test]
        public void TestAddTaskCorrect()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            UserTaskView task = new UserTaskView();

            Assert.DoesNotThrow(() => presenter.AddTask(task));
        }

        [Test]
        public void TestAddNullTask()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            UserTaskView task = null;

            Assert.Throws<NullTaskException>(() => presenter.AddTask(task));
        }

        [Test]
        public void TestEditTaskCorrect()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            UserTaskView task = new UserTaskView();

            Assert.DoesNotThrow(() => presenter.EditTask(task));
        }

        [Test]
        public void TestEditNullTask()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            UserTaskView task = null;

            Assert.Throws<NullTaskException>(() => presenter.EditTask(task));
        }

        [Test]
        public void TestRemoveTaskCorrect()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            UserTaskView task = new UserTaskView();

            Assert.DoesNotThrow(() => presenter.RemoveTask(task));
        }

        [Test]
        public void TestRemoveNullTask()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            UserTaskView task = null;

            Assert.Throws<NullTaskException>(() => presenter.RemoveTask(task));
        }

        [Test]
        public void TestLoadAllTasksCorrect()
        {
            var tasks = GenerateCorrectUserTasksList();
            var dataModelFake = new DataModelFake(tasks);
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            Assert.AreEqual(tasks.Count, presenter.LoadAllTasks().Count);
        }

        [Test]
        public void TestLoadTasksOfDayCorrect()
        {
            var tasks = GenerateCorrectUserTasksList();
            var dataModelFake = new DataModelFake(tasks);
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            var date = new DateTime(2018, 1, 1);

            Assert.AreEqual(tasks.Count(t => t.TaskDate == date), presenter.LoadTasksOfDay(date).Count);
        }


        [Test]
        public void TestLoadTasksOfDaysCorrect()
        {
            var tasks = GenerateCorrectUserTasksList();
            var dataModelFake = new DataModelFake(tasks);
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverterStub());

            var dateInterval = new DateInterval(new DateTime(2018, 1, 1), new DateTime(2018, 1, 2));

            Assert.AreEqual(tasks.Count(t => t.TaskDate >= dateInterval.BeginDate && t.TaskDate <= dateInterval.EndDate), 
                            presenter.LoadTasksOfDays(dateInterval).Count);
        }

        //Можно добавить тесты на маппинг (с Moq)

        private List<UserTask> GenerateCorrectUserTasksList()
        {
            return new List<UserTask>
            {
                new UserTask
                {
                    Id = 1,
                    Name = "TaskName1",
                    Description = "TaskDescription1",
                    IsNotified = true,
                    Priority = 1,
                    TaskDate = new DateTime(2018, 1, 1),
                    NotifyDate = new DateTime(2018, 1, 1)
                },
                new UserTask
                {
                    Id = 2,
                    Name = "TaskName2",
                    Description = "TaskDescription2",
                    IsNotified = false,
                    Priority = 2,
                    TaskDate = new DateTime(2018, 1, 2),
                    NotifyDate = new DateTime(2018, 1, 1)
                },
                new UserTask
                {
                    Id = 3,
                    Name = "TaskName3",
                    Description = "TaskDescription3",
                    IsNotified = true,
                    Priority = 3,
                    TaskDate = new DateTime(2018, 1, 3),
                    NotifyDate = new DateTime(2018, 1, 1)
                },
            };
        }

        private class DatesForTest
        {
            public static IEnumerable TestCase
            {
                get
                {
                    yield return new TestCaseData(new DateTime(2018, 1, 1));
                    yield return new TestCaseData(new DateTime(2018, 1, 2));
                    yield return new TestCaseData(new DateTime(2018, 1, 3));
                }
            }
        }
    }
}
