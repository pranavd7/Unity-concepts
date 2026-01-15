using UnityEngine;

public class IntArrayQueue
{
    private int[] data;
    private int front;   // index of first element
    private int rear;    // index where next element will be inserted
    private int count;   // number of elements currently in queue

    public IntArrayQueue(int capacity)
    {
        data = new int[capacity];
        front = 0;
        rear = 0;
        count = 0;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public bool IsFull()
    {
        return count == data.Length;
    }

    public void Enqueue(int value)
    {
        if (IsFull())
        {
            Debug.Log("Queue is full");
            return;
        }

        data[rear] = value;
        rear = (rear + 1) % data.Length; // wrap around
        count++;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            Debug.Log("Queue is empty");
            return -1;
        }

        int value = data[front];
        front = (front + 1) % data.Length; // wrap around
        count--;
        return value;
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            Debug.Log("Queue is empty");
            return -1;
        }

        return data[front];
    }
}
