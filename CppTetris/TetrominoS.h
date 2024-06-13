#pragma once

#include "Tetromino.h"

class TetrominoS :
    public Tetromino
{

public:

    TetrominoS();

    std::vector<Vector> getBasePoints() override;
};