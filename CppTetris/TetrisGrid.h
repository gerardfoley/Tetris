#pragma once

#include <iostream>
#include "Grid.h"
#include "Windows.h"
#include "Tetromino.h"

class TetrisGrid {

public:

    TetrisGrid() : _grid(10, 20) {}
    void render();
    bool isColliding(Tetromino& tetromino);
    bool isColliding(Vector point);
    void set(Tetromino& tetromino);
    void clearLines();

private:
    Grid<WORD> _grid;
    void copyLineFromAbove(int line);
    bool lineIsFull(int line);

};