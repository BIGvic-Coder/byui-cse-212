using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueueItem
{
    public string Value { get; set; }
    public int Priority { get; set; }
    public int Order { get; set; }  // used to preserve insertion order

    public PriorityQueueItem(string value, int priority, int order)
    {
        Value = value;
        Priority = priority;
        Order = order;
    }
}

public class PriorityQueue
{
    private List<PriorityQueueItem> items = new List<PriorityQueueItem>();
    private int insertionOrder = 0;

    public void Enqueue(string value, int priority)
    {
        items.Add(new PriorityQueueItem(value, priority, insertionOrder));
        insertionOrder++;
    }

    public string Dequeue()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        // Find item with highest priority, and if tied, lowest order (FIFO)
        var highestPriority = items.Max(i => i.Priority);
        var highest = items
            .Where(item => item.Priority == highestPriority)
            .OrderBy(item => item.Order)
            .First();

        items.Remove(highest);

        return highest.Value;
    }
}
