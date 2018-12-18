using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagerModel;

namespace TaskManagerNotifier
{
    public class Notifier : INotifier, IDisposable
    {
        public event Action ShowMainWindow = delegate { };

        private readonly IDataModel _dataModel;

        private readonly NotifyIcon _notifyIcon;

        private DateTime appCurrentTime;

        private const int TICK_INTERVAL = 5000;

        private const int BALLOONTIP_SHOW_TIME = 3000;

        public Notifier(IDataModel dataModel)
        {
            _dataModel = dataModel;

            _notifyIcon = new NotifyIcon
            {
                Text = "TaskManager",
                Icon = new System.Drawing.Icon("appicon.ico"),
                Visible = true
            };
            _notifyIcon.DoubleClick += NotifyIconOnDoubleClick;

            _notifyIcon.BalloonTipTitle = "TaskManager";
            _notifyIcon.BalloonTipText = "Есть задачи, назначенные на сегодня!";

            Task.Run((Action)Tick);
        }

        public void OnTasksDataUpdated()
        {
            //CheckForNotifyDates();
        }

        private void CheckForNotifyDates()
        {
            try
            {
                var notifyDates = _dataModel.GetTaskNotifyDates(appCurrentTime); //lock?

                if(notifyDates.Count() == 0)
                    return;

                _notifyIcon.ShowBalloonTip(BALLOONTIP_SHOW_TIME);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Tick() //Завершать?
        {
            while (true)
            {
                if (appCurrentTime != DateTime.Today)
                {
                    appCurrentTime = DateTime.Today;
                    CheckForNotifyDates();
                }

                Thread.Sleep(TICK_INTERVAL);
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
