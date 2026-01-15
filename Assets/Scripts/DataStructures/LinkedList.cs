using System;
using UnityEngine;

public class LinkedList
{
    public class Node
    {
        public int Value;
        public Node Next;

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node head;
    public int Count { get; private set; }

    public LinkedList()
    {
        head = null;
        Count = 0;
    }

    // Insert at head
    public void AddFirst(int value)
    {
        Node n = new Node(value);
        n.Next = head;
        head = n;
        Count++;
    }

    // Insert at tail
    public void AddLast(int value)
    {
        Node n = new Node(value);
        if (head == null) 
            head = n;
        else
        {
            Node cur = head;
            while (cur.Next != null) 
                cur = cur.Next;
            cur.Next = n;
        }
        Count++;
    }

    // Remove first
    public int RemoveFirst()
    {
        if (head == null)
        {
            Debug.Log("List empty");
            return -1;
        }
        
        int val = head.Value;
        head = head.Next;
        Count--;
        return val;
    }

    // Find by value
    public Node Find(int value)
    {
        Node cur = head;
        while (cur != null)
        {
            if (cur.Value == value) 
                return cur;
            cur = cur.Next;
        }
        return null;
    }

    // Print list (for demo)
    public void PrintAll()
    {
        Node cur = head;
        while (cur != null)
        {
            Debug.Log(cur.Value + " -> ");
            cur = cur.Next;
        }
        Debug.Log("NULL");
    }
}
