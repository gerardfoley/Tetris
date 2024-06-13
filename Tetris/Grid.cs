namespace Tetris;

internal sealed class Grid<T>
{
    private readonly List<T> _list = [];

    public Grid(int width, int height)
    {
        _list.AddRange(Enumerable.Repeat<T>(default!, width * height));

        Width = width; 
        Height = height;
    }

    public int Width { get; }

    public int Height { get; }

    public T this[int x, int y]
    {
        get
        {
            ThrowIfNotValid(x, y);
            return _list[x + y * Width];
        }
        set
        {
            ThrowIfNotValid(x, y);
            _list[x + y * Width] = value;
        }
    }

    public bool IsValid(int x, int y)
    {
        if(x < 0 || x >= Width) { return false; }
        if(y < 0 || y >= Height) { return false; }
        return true;
    }

    private void ThrowIfNotValid(int x, int y)
    {
        if(!IsValid(x, y))
        {
            throw new IndexOutOfRangeException();
        }
    }
}