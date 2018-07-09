using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeWithRoughSetTheory
{
    class TreeNode
    {
        public TreeNode(string name, int tableIndex, Attributes nodeAttribute, string edge)
        {
            Name = name;
            TableIndex = tableIndex;
            NodeAttribute = nodeAttribute;
            ChildNodes = new List<TreeNode>();
            Edge = edge;
        }

        public TreeNode(bool isleaf, string name, string edge)
        {
            IsLeaf = isleaf;
            Name = name;
            Edge = edge;
        }
        //sua
        public string Name { get; set; }

        public string Edge { get; set; }

        public Attributes NodeAttribute { get; set; }

        public List<TreeNode> ChildNodes { get; set; }

        public int TableIndex { get; set; }

        public bool IsLeaf { get; set; }
    }
}
