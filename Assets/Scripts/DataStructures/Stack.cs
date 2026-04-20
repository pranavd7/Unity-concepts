using UnityEngine;

public class IntArrayStack
{
    private int[] data;
    private int top; // index of the last pushed element

    public IntArrayStack(int capacity)
    {
        data = new int[capacity];
        top = -1; // empty stack
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public bool IsFull()
    {
        return top == data.Length - 1;
    }

    public void Push(int value)
    {
        if (IsFull())
        {
            Debug.Log("Stack is full");
            return;
        }

        top++;
        data[top] = value;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Debug.Log("Stack is empty");
            return -1;
        }

        int value = data[top];
        top--;
        return value;
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            Debug.Log("Stack is empty");
            return -1;
        }

        return data[top];
    }

    public int GetCount()
    {
        return top + 1;
    }
}
