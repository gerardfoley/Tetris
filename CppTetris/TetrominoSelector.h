#pragma once

#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
#include <random>
#include "Tetromino.h"
#include "TetrominoO.h"
#include "TetrominoT.h"
#include "TetrominoI.h"
#include "TetrominoL.h"
#include "TetrominoJ.h"
#include "TetrominoS.h"
#include "TetrominoZ.h"

class TetrominoSelector {

private:

    std::random_device rd;
    std::default_random_engine _rng = std::default_random_engine{ rd() };
    std::queue<Tetromino*> _tetrominos;

    void ensure() {

        if (_tetrominos.empty()) {
            generateNextBatch();
        }
    }

    void generateNextBatch() {

        std::vector<Tetromino*> tetrominos;

        tetrominos.push_back(new TetrominoT());
        tetrominos.push_back(new TetrominoO());
        tetrominos.push_back(new TetrominoI());
        tetrominos.push_back(new TetrominoL());
        tetrominos.push_back(new TetrominoJ());
        tetrominos.push_back(new TetrominoS());
        tetrominos.push_back(new TetrominoZ());

        std::shuffle(std::begin(tetrominos), std::end(tetrominos), _rng);

        for (auto tetromino : tetrominos) {
            _tetrominos.push(tetromino);
        }
    }

public:

    Tetromino* getNext() {

        ensure();
        Tetromino* nextTetromino = _tetrominos.front();
        _tetrominos.pop();
        return nextTetromino;
    }

    Tetromino* peekNext() {

        ensure();
        return _tetrominos.front();
    }
};