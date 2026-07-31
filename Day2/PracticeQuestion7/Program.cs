using System;
using System.Collections.Generic;

class TreeNode
{
    public string Value { get; set; }
    public List<TreeNode> Children { get; set; }

    public TreeNode(string value)
    {
        Value = value;
        Children = new List<TreeNode>();
    }
}

class Program
{
    static List<string> FlattenTree(params TreeNode[] rootNodes)
    {
        List<string> result = new List<string>();

        void Traverse(TreeNode node, ref int depth)
        {
            result.Add(node.Value);

            Console.WriteLine($"{node.Value}: depth {depth}");

            foreach (TreeNode child in node.Children)
            {
                depth++;

                Traverse(child, ref depth);

                depth--;
            }
        }

        foreach (TreeNode root in rootNodes)
        {
            int depth = 0;

            Traverse(root, ref depth);
        }

        return result;
    }

    static void Main()
    {
        TreeNode root1 = new TreeNode("A");

        root1.Children.Add(new TreeNode("A1"));
        root1.Children.Add(new TreeNode("A2"));

        TreeNode root2 = new TreeNode("B");

        TreeNode b1 = new TreeNode("B1");

        b1.Children.Add(new TreeNode("B1a"));
        b1.Children.Add(new TreeNode("B1b"));

        root2.Children.Add(b1);

        TreeNode root3 = new TreeNode("C");

        List<string> flattened =
            FlattenTree(root1, root2, root3);

        Console.WriteLine("\nFlattened List:");

        Console.WriteLine(
            "[\"" + string.Join("\", \"", flattened) + "\"]"
        );
    }
}