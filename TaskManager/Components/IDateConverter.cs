using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Components
{
    public interface IDateConverter
    {
        DateTime ParseDateToString(string date);
        string ConvertDateToString(DateTime date);
    }
}
