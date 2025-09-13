using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 items with different priorities and have the higher priority items dequeue first. 
    // Expected Result: [First, Second, Last] in this order
    // Defect(s) Found: Three errors: first is in dequeue the queue item was not removed so that was fixed.  Second was in the for loop it should be index < _queue.Count not index < _queue.Count - 1. Third was the comparison should be > not >= to ensure first in with same priority is dequeued first.
    public void TestPriorityQueue_1()
    {

        var expectedResult = new List<string> { "First", "Second", "Third", "Last" };

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Last", 1);
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);

        for (int i = 0; i < expectedResult.Count; i++)
        {
            Console.WriteLine(priorityQueue.ToString());
            var value = priorityQueue.Dequeue();
            Console.WriteLine($"Dequeued: {value}. Queue is now: {priorityQueue.ToString()}");
            Assert.AreEqual(expectedResult[i], value);
        }
    
    }

    [TestMethod]
    // Scenario: Check what happens when the queue is empty. 
    // Expected Result: should display error that the que is empty
    // Defect(s) Found: none
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
        
    }

    // Add more test cases as needed below.
}