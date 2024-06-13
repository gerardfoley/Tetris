#pragma once
#include "Tetromino.h"

class TetrominoO :
    public Tetromino
{
private:
    std::vector<Vector> basePoints;

public:
    
    TetrominoO();

    std::vector<Vector> getBasePoints() override 
    {
        return basePoints;
    }
};