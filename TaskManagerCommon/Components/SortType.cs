using System.ComponentModel;

namespace TaskManagerCommon.Components
{
    public enum SortType
    {
        [Description("Неопределено")]
        Undefined,
        [Description("Приоритет по возростанию")]
        AscendingPriority,
        [Description("Приоритет по убыванию")]
        DescendingPriority
    }
}
