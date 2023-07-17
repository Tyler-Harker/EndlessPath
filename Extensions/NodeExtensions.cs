using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace EndlessPath.Extensions
{
    public static class NodeExtensions
    {
        //public static List<T> GetNodesByName<T>(this Node node, string name, List<T>? nodes = null) where T : Node
        //{
        //    if (nodes is null)
        //    {
        //        nodes = new();
        //    }

        //    var children = node.GetChildren();

        //    if (node.Name.Equals(name))
        //    {
        //        nodes.Add(node as T);
        //    }

        //    foreach (var child in children)
        //    {
        //        nodes.AddRange(child.GetNodesByName<T>());
        //        children.AddRange(child.GetNodesByName<T>(name, nodes));
        //    }

        //    return nodes;
        //}
    }
}
