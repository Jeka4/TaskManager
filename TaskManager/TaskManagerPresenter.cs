using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class TaskManagerPresenter
    {
        MainWindow _mainWindow;

        public TaskManagerPresenter()
        {
            _mainWindow = new MainWindow();
            _mainWindow.Show();
        }
    }
}
