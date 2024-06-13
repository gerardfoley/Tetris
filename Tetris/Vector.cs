namespace Tetris;

public readonly record struct Vector(int X, int Y)
{
    public readonly static Vector Zero = new(0, 0);

    public Vector Left(int amount = 1) => new (X - amount, Y);
    public Vector Right(int amount = 1) => new (X + amount, Y);
    public Vector Down(int amount = 1) => new (X, Y + amount);
    public Vector Up(int amount = 1) => new (X, Y - amount);

    public Vector ScaleX(int amount) => new (X * amount, Y);
    public Vector ScaleY(int amount) => new (X, Y * amount);

    public static Vector operator+ (Vector v1, Vector v2) 
        => new(v1.X + v2.X, v1.Y + v2.Y);

    public override string ToString() => $"({X}, {Y})";
}