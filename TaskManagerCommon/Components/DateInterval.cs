using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCommon.Components
{
    public struct DateInterval
    {
        public DateTime BeginDate;
        public DateTime EndDate;

        public DateInterval(DateTime day) : this(day, day) { }

        public DateInterval(DateTime beginDate, DateTime endDate)
        {
            BeginDate = beginDate;
            EndDate = endDate;
        }
    }
}
