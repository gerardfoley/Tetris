#pragma once

#include "Tetromino.h"

class TetrominoZ :
    public Tetromino
{

public:

    TetrominoZ();

    std::vector<Vector> getBasePoints() override;
};