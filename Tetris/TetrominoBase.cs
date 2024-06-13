namespace Tetris;

internal abstract class TetrominoBase
{
    public Vector Position { get; set; }

    public Rotation Rotation { get; set; }

    public ConsoleColor Color { get; set; }

    public void MoveLeft()
    {
        Position = Position.Left();
    }

    public void MoveRight()
    {
        Position = Position.Right();
    }

    public void MoveUp()
    {
        Position = Position.Up();
    }

    public void MoveDown()
    {
        Position = Position.Down();
    }

    public void RotateAntiClockwise()
    {
        Rotation -= 1;

        if (Rotation < Rotation.Rotation0)
        {
            Rotation = Rotation.Rotation270;
        }
    }

    public void RotateClockwise()
    {
        Rotation += 1;

        if(Rotation > Rotation.Rotation270)
        {
            Rotation = Rotation.Rotation0;
        }
    }

    public void Render(Vector point)
    {
        Console.BackgroundColor = Color;

        foreach (var p in GetPoints())
        {
            RenderPoint(p + point);
        }

        Console.ResetColor();
    }

    public IEnumerable<Vector> GetPoints()
    {
        foreach (var point in GetBasePoints())
        {
            yield return point + Position;
        }
    }

    public abstract IEnumerable<Vector> GetBasePoints();

    protected static void RenderPoint(Vector point)
    {
        ConsoleUtils.SetCursorPosition(point.ScaleX(2));
        Console.Write("  ");
    }
}

internal sealed class TetrominoO : TetrominoBase
{
    public TetrominoO()
    {
        Color = ConsoleColor.Yellow;
    }

    public override IEnumerable<Vector> GetBasePoints()
    {
        yield return new Vector(0, 0);
        yield return new Vector(1, 0);
        yield return new Vector(0, 1);
        yield return new Vector(1, 1);
    }
}

internal sealed class TetrominoT : TetrominoBase
{
    public TetrominoT()
    {
        Color = ConsoleColor.Magenta;
    }

    public override IEnumerable<Vector> GetBasePoints()
    {
        if(Rotation == Rotation.Rotation0)
        {
            yield return new Vector(0, 1);
            yield return new Vector(1, 1);
            yield return new Vector(2, 1);
            yield return new Vector(1, 2);
        }
        else if (Rotation == Rotation.Rotation90)
        {
            yield return new Vector(0, 1);
            yield return new Vector(1, 0);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
        }
        else if (Rotation == Rotation.Rotation180)
        {
            yield return new Vector(0, 1);
            yield return new Vector(1, 1);
            yield return new Vector(2, 1);
            yield return new Vector(1, 0);
        }
        else if (Rotation == Rotation.Rotation270)
        {
            yield return new Vector(1, 0);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
            yield return new Vector(2, 1);
        }
    }
}

internal sealed class TetrominoI : TetrominoBase
{
    public TetrominoI()
    {
        Color = ConsoleColor.Cyan;
    }

    public override IEnumerable<Vector> GetBasePoints()
    {
        if (Rotation == Rotation.Rotation0 || Rotation == Rotation.Rotation180)
        {
            yield return new Vector(1, 0);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
            yield return new Vector(1, 3);
        }
        else if (Rotation == Rotation.Rotation90 || Rotation == Rotation.Rotation270)
        {
            yield return new Vector(0, 1);
            yield return new Vector(1, 1);
            yield return new Vector(2, 1);
            yield return new Vector(3, 1);
        }
    }
}

internal sealed class TetrominoL : TetrominoBase
{
    public TetrominoL()
    {
        Color = ConsoleColor.DarkYellow;
    }

    public override IEnumerable<Vector> GetBasePoints()
    {
        if (Rotation == Rotation.Rotation0)
        {
            yield return new Vector(1, 0);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
            yield return new Vector(2, 2);
        }
        else if (Rotation == Rotation.Rotation90)
        {
            yield return new Vector(0, 1);
            yield return new Vector(1, 1);
            yield return new Vector(2, 1);
            yield return new Vector(0, 2);
        }
        else if (Rotation == Rotation.Rotation180)
        {
            yield return new Vector(0, 0);
            yield return new Vector(1, 0);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
        }
        else if (Rotation == Rotation.Rotation270)
        {
            yield return new Vector(0, 1);
            yield return new Vector(1, 1);
            yield return new Vector(2, 1);
            yield return new Vector(2, 0);
        }
    }
}

internal sealed class TetrominoJ : TetrominoBase
{
    public TetrominoJ()
    {
        Color = ConsoleColor.Blue;
    }

    public override IEnumerable<Vector> GetBasePoints()
    {
        if (Rotation == Rotation.Rotation0)
        {
            yield return new Vector(1, 0);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
            yield return new Vector(0, 2);
        }
        else if (Rotation == Rotation.Rotation90)
        {
            yield return new Vector(0, 1);
            yield return new Vector(1, 1);
            yield return new Vector(2, 1);
            yield return new Vector(0, 0);
        }
        else if (Rotation == Rotation.Rotation180)
        {
            yield return new Vector(2, 0);
            yield return new Vector(1, 0);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
        }
        else if (Rotation == Rotation.Rotation270)
        {
            yield return new Vector(0, 1);
            yield return new Vector(1, 1);
            yield return new Vector(2, 1);
            yield return new Vector(2, 2);
        }
    }
}

internal sealed class TetrominoS : TetrominoBase
{
    public TetrominoS()
    {
        Color = ConsoleColor.Green;
    }

    public override IEnumerable<Vector> GetBasePoints()
    {
        if (Rotation == Rotation.Rotation0)
        {
            yield return new Vector(0, 2);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
            yield return new Vector(2, 1);
        }
        else if (Rotation == Rotation.Rotation90)
        {
            yield return new Vector(0, 0);
            yield return new Vector(0, 1);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
        }
        else if (Rotation == Rotation.Rotation180)
        {
            yield return new Vector(0, 1);
            yield return new Vector(1, 1);
            yield return new Vector(1, 0);
            yield return new Vector(2, 0);
        }
        else if (Rotation == Rotation.Rotation270)
        {
            yield return new Vector(1, 0);
            yield return new Vector(1, 1);
            yield return new Vector(2, 1);
            yield return new Vector(2, 2);
        }
    }
}

internal sealed class TetrominoZ : TetrominoBase
{
    public TetrominoZ()
    {
        Color = ConsoleColor.Red;
    }

    public override IEnumerable<Vector> GetBasePoints()
    {
        if (Rotation == Rotation.Rotation0)
        {
            yield return new Vector(0, 1);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
            yield return new Vector(2, 2);
        }
        else if (Rotation == Rotation.Rotation90)
        {
            yield return new Vector(1, 0);
            yield return new Vector(1, 1);
            yield return new Vector(0, 1);
            yield return new Vector(0, 2);
        }
        else if (Rotation == Rotation.Rotation180)
        {
            yield return new Vector(0, 0);
            yield return new Vector(1, 0);
            yield return new Vector(1, 1);
            yield return new Vector(2, 1);
        }
        else if (Rotation == Rotation.Rotation270)
        {
            yield return new Vector(2, 0);
            yield return new Vector(2, 1);
            yield return new Vector(1, 1);
            yield return new Vector(1, 2);
        }
    }
}