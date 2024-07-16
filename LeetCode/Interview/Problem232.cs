namespace LeetCode.Interview;
/// <summary>
///     232. Implement Queue using Stacks
///     https://leetcode.com/problems/implement-queue-using-stacks
/// </summary>
public class Problem232
{
    [Fact]
    public void MyQueueTest()
    {
        MyQueue myQueue = new();
        Queue<int> queue = new();
        myQueue.Push(1); // queue is: [1]
        queue.Enqueue(1);
        myQueue.S1.Should().BeEquivalentTo(queue);
        myQueue.Push(2); // queue is: [1, 2] (leftmost is front of the queue)
        queue.Enqueue(2);
        myQueue.S1.Should().BeEquivalentTo(queue);
        int peek = queue.Peek();
        myQueue.Peek().Should().Be(peek); // return 1
        int dequeue = queue.Dequeue();
        myQueue.Pop().Should().Be(dequeue); // return 1, queue is [2]
        myQueue.Empty().Should().BeFalse(); // return false
    }
}

public class MyQueue
{
    private readonly Stack<int> _s2 = new();
    public Stack<int> S1 { get; } = new();


    public void Push(int x)
    {
        while ( S1.Count > 0 )
        {
            _s2.Push(S1.Pop());
        }

        S1.Push(x);

        while ( _s2.Count > 0 )
        {
            S1.Push(_s2.Pop());
        }
    }

    public int Pop() => S1.Pop();

    public int Peek() => S1.Peek();

    public bool Empty() => S1.Count == 0;
}
