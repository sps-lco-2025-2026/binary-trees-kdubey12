namespace BinaryTreeClass.Lib;

public class BinaryTree
{
    BinaryTreeNode? _root;

    public BinaryTree()
    {
        _root = null;
    }

    public BinaryTree(int v)
    {
        _root = new BinaryTreeNode(v);
    }

    public void Insert(int v)
    {
        if (_root == null) _root = new BinaryTreeNode(v);
        else _root.Insert(v);
    }

    public bool Contains(int v)
    {
        if (_root == null) return false;
        else return _root.Contains(v);
    }

    public int Sum()
    {
        if (_root == null) return 0;
        else return _root.Sum();
    }

    public bool HasDuplicates()
    {
        if (_root == null) return false;
        else return _root.HasDuplicates([]);
    }

    public int Depth()
    {
        if (_root == null) return 0;
        else return _root.Depth(0);
    }

    public bool IsBalanced()
    {
        if (_root == null) return false;
        else return _root.IsBalanced();
    }

    private List<int> InOrder()
    {
        if (_root == null) return [];
        else return _root.InOrder();
    }

    public override string ToString()
    {
        return $"{{{string.Join(", ", InOrder())}}}";
    }
}

public class BinaryTreeNode
{
    int _value;
    BinaryTreeNode? _lower;
    BinaryTreeNode? _higher;

    internal BinaryTreeNode(int v)
    {
        _value = v;
        _lower = null;
        _higher = null;
    }

    internal BinaryTreeNode(int v, int l, int h)
    {
        _value = v;
        _lower = new BinaryTreeNode(l);
        _higher = new BinaryTreeNode(h);
    }

    internal void Insert(int v)
    {
        if (v <= _value)
        {
            if (_lower == null) _lower = new BinaryTreeNode(v);
            else _lower.Insert(v);
        }
        else
        {
            if (_higher == null) _higher = new BinaryTreeNode(v);
            else _higher.Insert(v);
        }
    }

    internal bool Contains(int v)
    {
        if (v == _value) return true;
        if (v < _value) return _lower?.Contains(v) ?? false;
        else return _higher?.Contains(v) ?? false;
    }

    internal int Sum()
    {
        return _value + (_higher?.Sum() ?? 0) + (_lower?.Sum() ?? 0);
    }

    internal bool HasDuplicates(HashSet<int> seen)
    {
        if (seen.Contains(_value)) return true;
        seen.Add(_value);
        return (_lower?.HasDuplicates(seen) ?? false) || (_higher?.HasDuplicates(seen) ?? false);
    }

    internal int Depth(int depth)
    {
        if (_lower == null && _higher == null) return depth;
        else return Math.Max(_lower?.Depth(depth+1) ?? depth, _higher?.Depth(depth+1) ?? depth);
    }

    internal bool IsBalanced()
    {
        int lowerDepth = _lower?.Depth(0) ?? 0;
        int higherDepth = _higher?.Depth(0) ?? 0;

        if (Math.Abs(lowerDepth - higherDepth) > 1) return false;
        else return _lower?.IsBalanced() ?? true & _higher?.IsBalanced() ?? true;
    }

    internal List<int> InOrder()
    {
        List<int> path = [];
        if (_lower != null) path.AddRange(_lower.InOrder());
        path.Add(_value);
        if (_higher != null) path.AddRange(_higher.InOrder());

        return path;
    }
}
