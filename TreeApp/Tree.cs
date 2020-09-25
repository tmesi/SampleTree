using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeApp
{
  using System.IO;

  /// <summary>
  /// Tree
  /// </summary>
  public class Tree
  {


    /// <summary>
    /// Constructor
    /// </summary>
    public Tree()
    {
      Root = new Node();
      Root.Level = 0;
      Root.Name = "Root";
    }

    public Tree(string path) : this()
    {
      InitializeTree(path);
    }

    /// <summary>
    /// Root of the tree
    /// </summary>
    public Node Root { get; set; }

    /// <summary>
    /// helper property for current node
    /// </summary>
    private Node Current { get; set; }

    /// <summary>
    /// Possible property for size
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// helper property for current level
    /// </summary>
    private int CurrentLevel { get; set; }


    private void InitializeTree(string path)
    {
      var lines = File.ReadAllLines(path);

      int level;
      // 0 = Level 1, 1 = Leve 2
      foreach (var line in lines)
      {
        level = line.Count(l => l == '\t');
        var nodeLevel = level + 1;
        var nodeName = line.TrimStart('\t');
        Node node = new Node();
        node.Name = nodeName;
        node.Level = nodeLevel;

        if (Root.Nodes.Count == 0)
        {
          Root.Nodes.Add(node);
          node.Parent = Root;
          Current = node; // for learning purposes placed here
        }
        else if (nodeLevel == 1)
        {
          Root.Nodes.Add(node);
          node.Parent = Root;
          Current = node;
        }
        else if (nodeLevel > CurrentLevel)
        {
          Current.Nodes.Add(node);
          node.Parent = Current;
          Current = node;

        }
        else if (nodeLevel == CurrentLevel)
        {
          Current.Parent.Nodes.Add(node);
          node.Parent = Current.Parent;
          Current = node;

        }
        else if (nodeLevel < CurrentLevel)
        {
          Current.Parent.Parent.Nodes.Add(node);
          node.Parent = Current.Parent.Parent;
          Current = node;
        }

        CurrentLevel = nodeLevel;

      }

    }

    /// <summary>
    /// Display tree in console
    /// </summary>
    public void PrintTree()
    {
      foreach (var rootNode in Root.Nodes)
      {
        Console.WriteLine($"Name: {rootNode.Name} - Level: {rootNode.Level}");
        PrintTreeInternal(rootNode.Nodes);
      }
    }

    private void PrintTreeInternal(List<Node> nodes)
    {
      foreach (var node in nodes)
      {
        Console.WriteLine($"   Name: {node.Name} - Level: {node.Level} | ParentName: {node.Parent.Name}");
        if (node.Nodes.Count > 0)
        {
          PrintTreeInternal(node.Nodes);
        }
      }
    }
  }
}
