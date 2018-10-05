using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public interface IMainWindow
    {
        void Show();
        void BindPresenter(ITaskManagerPresenter presenter);
    }
}
