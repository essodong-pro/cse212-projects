public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Only allow unique values
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, do nothing to maintain uniqueness
    }

    public bool Contains(int value)
    {
        // Problem 2: Search for a value in the tree
        if (value == Data)
            return true;

        if (value < Data)
            return Left != null && Left.Contains(value);

        return Right != null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // Problem 4: Get the height of the tree
        // Height is 1 (this node) + the maximum height of the subtrees
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}