using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add A(1), B(3), C(2) → Highest priority is B
    // Expected Result: Dequeue should return "B"
    // Defect(s) Found: If another item is returned, priority logic is broken
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        var result = pq.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Add A(5), B(5), C(5) → All same priority, so FIFO should apply
    // Expected Result: Dequeue should return "A"
    // Defect(s) Found: If B or C is returned, FIFO logic is broken
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);

        var result = pq.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue
    // Expected Result: InvalidOperationException
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }
}
