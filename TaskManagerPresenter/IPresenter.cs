﻿using System;
using System.Collections.Generic;
using TaskManagerCommon.Components;
using TaskManagerView.Components;

namespace TaskManagerPresenter
{
    public interface IPresenter
    {
        void Initialize();
        void ShowWindow();
        void SortTypeChange(SortType sort);
        void FilterTypeChange(FilterType filter);
        void SelectionListUpdated();
        void AddTask(UserTaskView task);
        void RemoveTask(UserTaskView task);
        void EditTask(UserTaskView task);
        void RefreshViewTasksList(DateInterval dateInterval);
        void RefreshViewHighlightList();
        List<UserTaskView> LoadTasksOfDay(DateTime day);
        List<UserTaskView> LoadTasksOfDays(DateInterval dayInterval);
        List<UserTaskView> LoadAllTasks();
    }
}
