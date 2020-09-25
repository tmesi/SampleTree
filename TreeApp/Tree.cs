using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeApp
{
  using System.IO;

  public class Tree
  {

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

    public Node Root { get; set; }

    public Node Current { get; set; }

    public int Size { get; set; }

    public int CurrentLevel { get; set; }


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
          Current = node;
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
