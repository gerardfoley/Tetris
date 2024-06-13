namespace Tetris;
 
internal sealed class Tetris
{
    private readonly Timer _dropTimer = new(30);
    private readonly TetrisGrid _tetrisGrid = new();
    private TetrominoBase _tetromino;
    private readonly TetrominoSelector _selector = new();
    private bool _updateFlag;

    public Tetris()
    {
        _tetromino = _selector.GetNext();
    }

    public async Task RunAsync()
    {
        while (true)
        {
            await LoopAsync();
        }
    }

    private Task LoopAsync()
    {
        var delay = Task.Delay(1000 / 30);

        HandleInput();
        Update();
        Render();

        return delay;
    }

    private void HandleInput()
    {
        if (!Console.KeyAvailable) { return; }

        var previousPosition = _tetromino.Position;
        var previousRotation = _tetromino.Rotation;

        var input = Console.ReadKey(true);

        ConsoleUtils.ClearBuffer();

        if (input.Key == ConsoleKey.LeftArrow)
        {
            _tetromino.MoveLeft();
            _updateFlag = true;
        }
        else if (input.Key == ConsoleKey.RightArrow)
        {
            _tetromino.MoveRight();
            _updateFlag = true;
        }
        else if (input.Key == ConsoleKey.DownArrow)
        {
            _tetromino.MoveDown();
            _updateFlag = true;
        }
        else if (input.Key == ConsoleKey.A)
        {
            _tetromino.RotateAntiClockwise();
            _updateFlag = true;
        }
        else if (input.Key == ConsoleKey.S)
        {
            _tetromino.RotateClockwise();
            _updateFlag = true;
        }

        if (_tetrisGrid.IsColiding(_tetromino))
        {
            _tetromino.Position = previousPosition;
            _tetromino.Rotation = previousRotation;
            _updateFlag = false;
        }
    }

    private void Update()
    {
        _dropTimer.Update();

        if (_dropTimer.Value == 0)
        {
            _updateFlag = true;
            _tetromino.MoveDown();
        }

        if (_tetrisGrid.IsColiding(_tetromino))
        {
            _updateFlag = true;
            _tetromino.MoveUp();

            _tetrisGrid.Set(_tetromino);

            _tetromino = _selector.GetNext();
        }

        _tetrisGrid.ClearLines();
    }

    private void Render()
    {
        if (!_updateFlag) { return; }

        _updateFlag = false;

        Console.Clear();

        _tetrisGrid.Render();
        _tetromino.Render(Vector.Zero);
    }
}