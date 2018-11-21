using System.ComponentModel;

namespace TaskManagerCommon.Components
{
    public enum FilterType
    {
        [Description("Неопределено")]
        Undefined,
        [Description("Любой приоритет")]
        All,
        [Description("Низкий приоритет")]
        LowPriority,
        [Description("Средний приоритет")]
        MediumPriority,
        [Description("Высокий приоритет")]
        HighPriority
    }
}
