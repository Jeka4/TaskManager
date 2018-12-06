using System.Diagnostics;

namespace TaskManagerModel
{
    public partial class UserTasksDB
    {
        [Conditional("DEBUG")]
        partial void InitDataContext()
        {
            TurnTraceSwitchOn();
            WriteTraceLine = (message, displayName) => Debug.WriteLine($"{message} {displayName}");
        }
    }
}
