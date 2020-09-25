using System;

namespace TreeApp
{
  using System.IO;

  /// <summary>
  /// Program
  /// </summary>
  class Program
  {
    /// <summary>
    /// Main
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      var dir = Directory.GetCurrentDirectory();
      var tree =new Tree(string.Concat(dir, @"\Tree.txt"));
      tree.PrintTree();


    Console.ReadLine();
    }
  }
}
