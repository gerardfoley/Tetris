#include "Timer.h"

void Timer::update()
{
    if (_value == 0)
    {
        _value = _maxValue;
    }
    _value--;
}