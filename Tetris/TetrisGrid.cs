namespace Tetris;

internal sealed class TetrisGrid
{
    private readonly Grid<ConsoleColor> _grid = new(10, 20);

    public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.DarkBlue;

    public void Render()
    {
        for (int x = 0; x < _grid.Width; x++)
        {
            for (int y = 0; y < _grid.Height; y++)
            {
                Console.BackgroundColor = _grid[x, y];
                Console.SetCursorPosition(x * 2, y);
                Console.Write("  ");
            }
        }
    }

    public bool IsColiding(TetrominoBase tetromino)
    {
        foreach (var point in tetromino.GetPoints())
        {
            if (IsColiding(point)) { return true; }
        }
        
        return false;
    }

    public bool IsColiding(Vector point)
    {
        if (point.X < 0 || point.X > _grid.Width - 1) { return true; }
        if (point.Y < 0 || point.Y > _grid.Height - 1) { return true; }

        if (_grid[point.X, point.Y] != ConsoleColor.Black)
        {
            return true;
        }

        return false;
    }

    public void Set(TetrominoBase tetromino)
    {
        foreach (var point in tetromino.GetPoints())
        {
            _grid.Set(point, tetromino.Color);
        }
    }

    public void ClearLines()
    {
        for (int i = _grid.Height - 1; i > 0; i--)
        {
            if (LineIsFull(i))
            {
                CopyLineFromAbove(i);
            }
        }
    }

    private void CopyLineFromAbove(int line)
    {
        if (line == 0) { return; }

        for (int i = 0; i < _grid.Width; i++)
        {
            _grid[i, line] = _grid[i, line - 1];
        }

        CopyLineFromAbove(line - 1);
    }

    private bool LineIsFull(int line)
    {
        for (int i = 0; i < _grid.Width - 1; i++)
        {
            if (_grid[i, line] == ConsoleColor.Black)
            {
                return false;
            }
        }

        return true;
    }
}