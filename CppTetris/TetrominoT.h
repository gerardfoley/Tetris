#pragma once

#include "Tetromino.h"

class TetrominoT :
    public Tetromino
{

public:

    TetrominoT();

    std::vector<Vector> getBasePoints() override;
};