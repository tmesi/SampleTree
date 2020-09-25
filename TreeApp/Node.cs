using System.Collections.Generic;

namespace TreeApp
{
  /// <summary>
  /// Node class
  /// </summary>
  public class Node
  {

    /// <summary>
    /// Constructor
    /// </summary>
    public Node()
    {
      Nodes = new List<Node>();
    }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
      
    /// <summary>
    /// Parent reference
    /// </summary>
    public Node Parent { get; set; }

    /// <summary>
    /// Level
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// Children nodes
    /// </summary>
    public List<Node> Nodes { get; set; }
  }
}
