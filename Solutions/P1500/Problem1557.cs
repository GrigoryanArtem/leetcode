namespace Solutions.P1500;

public class Problem1557
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        Span<byte> hasParent = stackalloc byte[n];
        for (int i = 0; i < edges.Count; i++)
            hasParent[edges[i][1]] = 1;

        var result = new List<int>();
        for (int i = 0; i < hasParent.Length; i++)
            if (hasParent[i] == 0)
                result.Add(i);

        return result;
    }
}
