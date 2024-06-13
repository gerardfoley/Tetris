#include "TetrominoO.h"
#include "Console.h"
#include <iostream>

TetrominoO::TetrominoO()
{
    color = BACKGROUND_YELLOW;

    basePoints.push_back(Vector(0, 0));
    basePoints.push_back(Vector(1, 0));
    basePoints.push_back(Vector(0, 1));
    basePoints.push_back(Vector(1, 1));
}