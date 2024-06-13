#pragma once

#include <vector>
#include <stdexcept>
#include "Vector.h"

template <typename T>
class Grid 
{
private:
    std::vector<T> _list;
    int _width;
    int _height;

    void throwIfNotValid(int x, int y) {

        if (!isValid(x, y)) {
            throw std::out_of_range("Invalid grid coordinates");
        }
    }

public:

    Grid(int width, int height) : _width(width), _height(height) {
        _list.resize(width * height);
    }

    T& get(int x, int y) {
        throwIfNotValid(x, y);
        return _list[x + y * _width];
    }

    void set(int x, int y, T value) {
        throwIfNotValid(x, y);
        _list[x + y * _width] = value;
    }

    void set(Vector point, T value) {
        throwIfNotValid(point.x, point.y);
        _list[point.x + point.y * _width] = value;
    }

    bool isValid(int x, int y) {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }

    int getHeight() {
        return _height;
    }

    int getWidth() {
        return _width;
    }
};