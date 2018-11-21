using System.ComponentModel;

namespace TaskManagerCommon.Components
{
    public enum TaskPriority
    {
        [Description("Неопределено")]
        Undefined = 0,
        [Description("Низкий приоритет")]
        Low = 1,
        [Description("Средний приоритет")]
        Medium = 2,
        [Description("Высокий приоритет")]
        High = 3
    }
}
