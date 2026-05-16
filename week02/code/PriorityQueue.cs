public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The item is always added to the back of the queue regardless of priority.
    /// </summary>
    /// <param name="value">The value to enqueue</param>
    /// <param name="priority">The priority (higher number = higher priority)</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return the value of the item with the highest priority.
    /// If multiple items share the highest priority, the earliest enqueued one is removed (FIFO).
    /// Throws InvalidOperationException if the queue is empty.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            // Requirement: must throw InvalidOperationException with this exact message
            throw new InvalidOperationException("The queue is empty.");
        }

        // Track the index of the current highest-priority item
        var highPriorityIndex = 0;

        // Iterate through all items to find the highest priority
        for (int index = 1; index < _queue.Count; index++)
        {
            // Use strict '>' to preserve FIFO order when priorities are equal
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
                highPriorityIndex = index;
        }

        // Remove the item and return its value
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    // DO NOT MODIFY THIS METHOD
    // The graders rely on this method to check correctness.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THIS METHOD
    // The graders rely on this method to check correctness.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
