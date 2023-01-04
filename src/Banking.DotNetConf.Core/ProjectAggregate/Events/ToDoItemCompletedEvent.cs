using Banking.DotNetConf.Core.ProjectAggregate;
using Banking.DotNetConf.SharedKernel;

namespace Banking.DotNetConf.Core.ProjectAggregate.Events;

public class ToDoItemCompletedEvent : BaseDomainEvent
{
    public ToDoItem CompletedItem { get; set; }

    public ToDoItemCompletedEvent(ToDoItem completedItem)
    {
        CompletedItem = completedItem;
    }
}
