using System;
using NUnit.Framework;
using TaskManagerCommon.Components;
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
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverter());

            Assert.DoesNotThrow(() => presenter.SortTypeChange(sort));
        }

        [Test]
        public void TestSortTypeChangeUndefined()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverter());

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
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverter());

            Assert.DoesNotThrow(() => presenter.FilterTypeChange(filter));
        }

        [Test]
        public void TestFilterTypeChangeUndefined()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverter());

            FilterType filter = FilterType.Undefined;

            Assert.Throws<ArgumentException>(() => presenter.FilterTypeChange(filter));
        }

        [Test]
        public void TestAddNullTask()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverter());

            UserTaskView task = null;

            Assert.Throws<NullTaskException>(() => presenter.AddTask(task));
        }

        [Test]
        public void TestAddCorrectTask()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverter());

            UserTaskView task = new UserTaskView
            {
                Description = "TaskDescription",
                Name = "TaskName",
                IsNotified = true,
                Priority = TaskPriority.Undefined
            };

            Assert.DoesNotThrow(() => presenter.AddTask(task));
        }

        [Test]
        public void TestEditCorrectTask()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverter());

            UserTaskView task = new UserTaskView
            {
                Description = "TaskDescription",
                Name = "TaskName",
                IsNotified = true,
                Priority = TaskPriority.Undefined
            };

            Assert.DoesNotThrow(() => presenter.EditTask(task));
        }

        [Test]
        public void TestEditNullTask()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverter());

            UserTaskView task = null;

            Assert.Throws<NullTaskException>(() => presenter.EditTask(task));
        }

        [Test]
        public void TestRemoveCorrectTask()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverter());

            UserTaskView task = new UserTaskView
            {
                Id = 1
            };

            Assert.DoesNotThrow(() => presenter.RemoveTask(task));
        }

        [Test]
        public void TestRemoveNullTask()
        {
            var dataModelFake = new DataModelFake();
            var presenter = new Presenter(new MainWindowFake(), dataModelFake, new PriorityConverter());

            UserTaskView task = null;

            Assert.Throws<NullTaskException>(() => presenter.RemoveTask(task));
        }


    }
}
