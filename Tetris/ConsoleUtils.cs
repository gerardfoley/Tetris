namespace Tetris;

public static class ConsoleUtils
{
    public static void SetCursorPosition(Vector vector)
    {
        Console.SetCursorPosition(vector.X, vector.Y);
    }

    public static void ClearBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey();
        }
    }
}