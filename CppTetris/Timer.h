#pragma once

class Timer 
{
private:
    int _maxValue;
    int _value;

public:
    Timer(int value) : _maxValue(value), _value(value) {}

    int getMaxValue() { return _maxValue; }
    int getValue() { return _value; }
    void update();
};