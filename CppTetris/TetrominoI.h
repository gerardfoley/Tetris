#pragma once

#include "Tetromino.h"

class TetrominoI :
    public Tetromino
{

public:

    TetrominoI();

    std::vector<Vector> getBasePoints() override;
};