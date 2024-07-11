using System.Collections;

namespace LeetCode.Interview;
/// <summary>
///     733. Flood Fill
///     https://leetcode.com/problems/flood-fill
/// </summary>
public class Problem733
{
    #region Queue Solution

    public int[][] FloodFillQueue(int[][] image, int sr, int sc, int color)
    {
        if ( image[sr][sc] == color )
        {
            return image;
        }

        Queue<(int, int)> neighbours = new();
        neighbours.Enqueue((sr, sc));
        int colorToChange = image[sr][sc];
        while ( neighbours.Count > 0 )
        {
            (int r, int c) = neighbours.Dequeue();
            if ( image[r][c] == colorToChange )
            {
                image[r][c] = color;
            }
            else
            {
                continue;
            }

            if ( r - 1 >= 0 )
            {
                neighbours.Enqueue((r - 1, c));
            }

            if ( c - 1 >= 0 )
            {
                neighbours.Enqueue((r, c - 1));
            }

            if ( r + 1 < image.Length )
            {
                neighbours.Enqueue((r + 1, c));
            }

            if ( c + 1 < image[r].Length )
            {
                neighbours.Enqueue((r, c + 1));
            }
        }

        return image;
    }

    #endregion

    [Theory]
    [ClassData(typeof(TestData))]
    public void CanFloodFill(int[][] image, int sr, int sc, int color, int[][] expected) => FloodFill(image, sr, sc, color).Should().BeEquivalentTo(expected);

    #region Recursive Solution

    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        if ( image[sr][sc] == color )
        {
            return image;
        }

        int rootColor = image[sr][sc];

        FloodFillRecursive(image, sr, sc, color, rootColor);

        return image;
    }

    private void FloodFillRecursive(int[][] image, int sr, int sc, int color, int rootColor)
    {
        if ( image[sr][sc] == rootColor )
        {
            image[sr][sc] = color;
        }
        else
        {
            return;
        }

        if ( sr - 1 >= 0 )
        {
            FloodFillRecursive(image, sr - 1, sc, color, rootColor);
        }

        if ( sc - 1 >= 0 )
        {
            FloodFillRecursive(image, sr, sc - 1, color, rootColor);
        }

        if ( sr + 1 < image.Length )
        {
            FloodFillRecursive(image, sr + 1, sc, color, rootColor);
        }

        if ( sc + 1 < image[sr].Length )
        {
            FloodFillRecursive(image, sr, sc + 1, color, rootColor);
        }
    }

    #endregion
}

public class TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        int[][] image = [[1, 1, 1], [1, 1, 0], [1, 0, 1]];
        int[][] expected = [[2, 2, 2], [2, 2, 0], [2, 0, 1]];
        yield return [image, 1, 1, 2, expected];

        image = [[0, 0, 0], [0, 0, 0]];
        expected = [[0, 0, 0], [0, 0, 0]];
        yield return [image, 0, 0, 0, expected];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
