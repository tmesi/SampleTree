using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
  using System.IO;

  class Program
  {
    static void Main(string[] args)
    {
      var dir = Directory.GetCurrentDirectory();
      var tree =new Tree(string.Concat(dir, @"\Tree.txt"));
      tree.PrintTree();


    Console.ReadLine();
    }
  }
}
