#pragma once

#include "Tetromino.h"

class TetrominoJ :
    public Tetromino
{

public:

    TetrominoJ();

    std::vector<Vector> getBasePoints() override;
};