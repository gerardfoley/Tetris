#pragma once

#include "Tetromino.h"

class TetrominoL :
    public Tetromino
{

public:

    TetrominoL();

    std::vector<Vector> getBasePoints() override;
};