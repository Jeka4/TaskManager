using System;
using System.Linq;
using System.Windows.Forms;
using TaskManagerModel;

namespace TaskManagerNotifier
{
    public class Notifier : INotifier, IDisposable
    {
        public event Action ShowMainWindow = delegate { };

        private readonly IDataModel _dataModel;

        private readonly NotifyIcon _notifyIcon;

        public Notifier(IDataModel dataModel)
        {
            _dataModel = dataModel;

            _notifyIcon = new NotifyIcon();
            _notifyIcon.Text = "TaskManager";
            _notifyIcon.Icon = new System.Drawing.Icon("appicon.ico");
            //_notifyIcon.ContextMenu = contextMenu;
            _notifyIcon.Visible = true;
            _notifyIcon.DoubleClick += NotifyIconOnDoubleClick;
        }

        public void OnTasksDataUpdated()
        {

        }

        private void LoadNotifyDates()
        {
            try
            {
                var notifyDates = _dataModel.GetAllTasks()
                                            .Where(t => t.TaskDate == DateTime.Today)
                                            .Select(t => t.NotifyDate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void NotifyIconOnDoubleClick(object sender, EventArgs eventArgs)
        {
            ShowMainWindow();
        }

        public void Dispose()
        {
            _notifyIcon.Dispose();
        }
    }
}
