using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities.
    // Expected Result: Dequeue returns the highest priority item ("C").
    // Defect(s) Found: Old implementation did not correctly check the last element.
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();
        Assert.AreEqual("C", result);
    }

    [TestMethod]
    // Scenario: Enqueue items with equal priority.
    // Expected Result: Dequeue returns the first enqueued item ("A").
    // Defect(s) Found: Old implementation ignored FIFO order.
    public void TestPriorityQueue_TieBreakingFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);

        var result = pq.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Old implementation threw wrong exception type or message.
    public void TestPriorityQueue_EmptyQueueException()
    {
        var pq = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with mixed priorities.
    // Expected Result: Items dequeued in correct priority order (High → Medium → Low).
    // Defect(s) Found: Old implementation sometimes returned items in insertion order.
    public void TestPriorityQueue_MixedPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Verify queue empties correctly after multiple Dequeue calls.
    // Expected Result: After removing all items, another Dequeue throws exception.
    public void TestPriorityQueue_QueueEmptiesCorrectly()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 2);
        pq.Enqueue("Y", 3);

        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("X", pq.Dequeue());
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }
}
