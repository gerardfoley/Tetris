namespace Tetris;

internal static class GridExtensions
{
    public static void CopyLineFromAbove<T>(this Grid<T> grid, int line)
    {
        for (int x = 0; x < grid.Width; x++)
        {
            grid[x, line] = grid[x, line - 1];
        }
    }

    public static void SetLineToDefault<T>(this Grid<T> grid, int line)
    {
        for (int x = 0; x < grid.Width; x++)
        {
            grid[x, line] = default!;
        }
    }

    public static void Set<T>(this Grid<T> grid, Vector point, T value)
    {
        grid[point.X, point.Y] = value;
    }

    public static void Set(this Grid<bool> grid, TetrominoBase tetromino)
    {
        foreach (var point in tetromino.GetBasePoints())
        {
            grid.Set(point, true);
        }
    }
}