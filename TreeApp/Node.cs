using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
  using System.Security.Policy;

  public class Node
  {

    public Node()
    {
      Nodes = new List<Node>();
    }

    public string Name { get; set; }
      
    public Node Parent { get; set; }

    public int Level { get; set; }

    public List<Node> Nodes { get; set; }
  }
}
