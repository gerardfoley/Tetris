#include "TetrisGrid.h"

void TetrisGrid::render()
{
    for (int x = 0; x < _grid.getWidth(); x++)
    {
        for (int y = 0; y < _grid.getHeight(); y++)
        {
            Console::setBackgroundColor(_grid.get(x, y));
            Console::setCursorPosition(x * 2, y);
            std::cout << "  ";
        }
    }
}

bool TetrisGrid::isColliding(Tetromino& tetromino) {

    for (const auto& point : tetromino.getPoints())
    {
        if (isColliding(point))
        {
            return true;
        }
    }
    return false;
}

bool TetrisGrid::isColliding(Vector point)
{
    if (point.x < 0 || point.x >= _grid.getWidth() || point.y < 0 || point.y >= _grid.getHeight())
    {
        return true;
    }

    if (_grid.get(point.x, point.y) != BLACK)
    {
        return true;
    }

    return false;
}

void TetrisGrid::set(Tetromino& tetromino)
{
    for (const auto& point : tetromino.getPoints())
    {
        _grid.set(point, tetromino.color);
    }
}

void TetrisGrid::clearLines()
{
    for (int i = _grid.getHeight() - 1; i > 0; i--)
    {
        if (lineIsFull(i))
        {
            copyLineFromAbove(i);
        }
    }
}

void TetrisGrid::copyLineFromAbove(int line)
{
    if (line == 0)
    {
        return;
    }

    for (int i = 0; i < _grid.getWidth(); i++)
    {
        auto value = _grid.get(i, line - 1);

        _grid.set(i, line, value);
    }

    copyLineFromAbove(line - 1);
}

bool TetrisGrid::lineIsFull(int line) {

    for (int i = 0; i < _grid.getWidth(); i++)
    {
        if (_grid.get(i, line) == BLACK)
        {
            return false;
        }
    }
    return true;
}