namespace Tetris;

internal sealed class Timer
{
    public Timer(int value)
    {
        MaxValue = value;
    }

    public int MaxValue { get; }

    public int Value { get; private set; }

    public void Update()
    {
        if(Value == 0)
        {
            Value = MaxValue;
        }
        
        Value--;
    }
}