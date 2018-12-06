using System;
using System.ComponentModel;
using TaskManagerCommon.Components;

namespace TaskManagerView.Components
{
    public class UserTaskView : IDataErrorInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime TaskDate { get; set; }
        public DateTime NotifyDate { get; set; }
        public bool IsNotified { get; set; }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case nameof(Id):
                        if (Id < 1)
                        {
                            error = "Id must be > 0";
                        }
                        break;
                    case nameof(Name):
                        if (Name == null)
                        {
                            error = "Name is null";
                        }
                        else if(Name == String.Empty)
                        {
                            error = "Name is empty";
                        }
                        break;
                    case nameof(Description):
                        if (Description == null)
                        {
                            error = "Description is null";
                        }
                        else if (Description == String.Empty)
                        {
                            error = "Description is empty";
                        }
                        break;
                    case nameof(Priority):
                        if (Priority == TaskPriority.Undefined)
                        {
                            error = "Priority is undefined";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
