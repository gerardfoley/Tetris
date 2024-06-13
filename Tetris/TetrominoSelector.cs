using System.Collections;

namespace Tetris;

internal class TetrominoSelector : IEnumerable<TetrominoBase>
{
    private readonly Queue<TetrominoBase> _tetrominos = [];

    public TetrominoBase GetNext()
    {
        Ensure();
        return _tetrominos.Dequeue();
    }

    public TetrominoBase PeekNext()
    {
        Ensure();
        return _tetrominos.Peek();
    }

    private void Ensure()
    {
        if(_tetrominos.Count == 0)
        {
            GenerateNextBatch();
        }
    }

    private void GenerateNextBatch()
    {
        IEnumerable<TetrominoBase> tetrominos = 
        [
            new TetrominoO(),
            new TetrominoT(),
            new TetrominoI(),
            new TetrominoL(),
            new TetrominoJ(),
            new TetrominoS(),
            new TetrominoZ(),
        ];

        foreach (var tetromino in tetrominos.OrderBy(x => Random.Shared.Next()))
        {
            _tetrominos.Enqueue(tetromino);
        }
    }

    public IEnumerator<TetrominoBase> GetEnumerator()
    {
        yield return GetNext();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}