using System;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode
{
    public int Value;
    public List<TreeNode> Children = new List<TreeNode>();

    public TreeNode(int value)
    {
        Value = value;
    }

    // Add child node
    public void AddChild(TreeNode child)
    {
        Children.Add(child);
    }

    // Remove child node (by reference)
    public void RemoveChild(TreeNode child)
    {
        Children.Remove(child);
    }
}

public class Tree
{
    public TreeNode Root;

    public Tree(int rootValue)
    {
        Root = new TreeNode(rootValue);
    }

    // Add a new child under a node with the given parentValue
    public bool Add(int parentValue, int newValue)
    {
        TreeNode parentNode = Find(Root, parentValue);

        if (parentNode == null)
            return false;   // parent not found

        parentNode.AddChild(new TreeNode(newValue));
        return true;
    }

    // Remove a node by value (removes entire subtree)
    public bool Remove(int value)
    {
        if (Root.Value == value)
            return false;

        return RemoveNode(Root, value);
    }

    // Helper recursive function to remove a node from children
    private bool RemoveNode(TreeNode current, int value)
    {
        foreach (var child in current.Children)
        {
            if (child.Value == value)
            {
                current.RemoveChild(child);
                return true;
            }
        }

        // otherwise search deeper
        foreach (var child in current.Children)
        {
            if (RemoveNode(child, value))
                return true;
        }

        return false; // not found
    }

    // Find a node by value (DFS search)
    public TreeNode Find(TreeNode node, int value)
    {
        if (node.Value == value) return node;

        foreach (var child in node.Children)
        {
            var found = Find(child, value);
            if (found != null)
                return found;
        }

        return null;
    }

    // Print tree (DFS)
    public void Print(TreeNode node, string indent = "")
    {
        Debug.Log(indent + node.Value);
        foreach (var child in node.Children)
        {
            Print(child, indent + "  ");
        }
    }
}
