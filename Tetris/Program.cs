namespace Tetris;

internal static class Program
{
    private static async Task Main()
    {
        Console.CursorVisible = false;
        Console.Title = "Console Tetris";
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        var game = new Tetris();
        await game.RunAsync();
    }
}