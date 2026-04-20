// SimpleGraph.cs
using System;
using System.Collections.Generic;

public class SimpleGraph
{
    // adjacency list: node id -> neighbors
    private Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

    // add node if not present
    public void AddNode(int id)
    {
        if (!adj.ContainsKey(id)) adj[id] = new List<int>();
    }

    // add undirected edge
    public void AddEdge(int a, int b)
    {
        AddNode(a); 
        AddNode(b);
        adj[a].Add(b);
        adj[b].Add(a);
    }

    // BFS from start (returns order visited)
    public List<int> BFS(int start)
    {
        var visited = new HashSet<int>();
        var order = new List<int>();
        var q = new Queue<int>();
        q.Enqueue(start);
        visited.Add(start);
        while (q.Count > 0)
        {
            int cur = q.Dequeue();
            order.Add(cur);
            foreach (var nb in adj[cur])
            {
                if (!visited.Contains(nb))
                {
                    visited.Add(nb);
                    q.Enqueue(nb);
                }
            }
        }
        return order;
    }

    // DFS (iterative)
    public List<int> DFS(int start)
    {
        var visited = new HashSet<int>();
        var order = new List<int>();
        var stack = new Stack<int>();
        stack.Push(start);
        while (stack.Count > 0)
        {
            int cur = stack.Pop();
            if (visited.Contains(cur)) continue;
            visited.Add(cur);
            order.Add(cur);
            foreach (var nb in adj[cur])
            {
                if (!visited.Contains(nb)) stack.Push(nb);
            }
        }
        return order;
    }
}
