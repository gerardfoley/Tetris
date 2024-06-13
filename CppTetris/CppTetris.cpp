#include <conio.h>
#include <iostream>
#include <windows.h>
#include <cstdlib>
#include <future>
#include "Vector.h"
#include "Console.h"
#include "Tetromino.h"
#include "TetrominoO.h"
#include "TetrominoT.h"
#include "Timer.h"
#include "TetrisGrid.h"
#include "TetrominoSelector.h"

#define KEY_UP 72
#define KEY_DOWN 80
#define KEY_LEFT 75
#define KEY_RIGHT 77

std::future<void> loopAsync();
static void update();
static void handleInput();
static void render();

TetrominoSelector selector;
Tetromino* tetromino;
Timer timer(30);
TetrisGrid grid;
bool updateFlag;

int main() {

    Console::hideCursor();

    tetromino = selector.getNext();

    while (true)
    {
        auto result = loopAsync();
        result.wait();
    } 
    
    return 0;
}

std::future<void> loopAsync() {

    auto delay = std::async(std::launch::async, []
    {
        std::this_thread::sleep_for(std::chrono::milliseconds(1000 / 30));
    });
    
    handleInput();
    update();
    render();

    return delay;
}

static void handleInput() {

    if (!_kbhit()) { return; }

    auto previousPosition = tetromino->position;
    auto previousRotation = tetromino->rotation;

    int c = 0;

    switch (c = _getch())
    {
    case KEY_LEFT:
        tetromino->moveLeft();
        updateFlag = true;
        break;

    case KEY_RIGHT:
        tetromino->moveRight();
        updateFlag = true;
        break;

    case KEY_DOWN:
        tetromino->moveDown();
        updateFlag = true;
        break;

    case 'a':
    case 'A':
        tetromino->rotateAntiClockwise();
        updateFlag = true;
        break;

    case 's':
    case 'S':
        tetromino->rotateClockwise();
        updateFlag = true;
        break;
    }

    if (grid.isColliding(*tetromino)) {

        tetromino->position = previousPosition;
        tetromino->rotation = previousRotation;
        updateFlag = false;
    }
}

static void update() {

    timer.update();

    if (timer.getValue() == 0)
    {
        updateFlag = true;
        tetromino->moveDown();
    }

    if (grid.isColliding(*tetromino)) {

        updateFlag = true;

        tetromino->moveUp();
        grid.set(*tetromino);

        tetromino = selector.getNext();

    }

    grid.clearLines();
}

static void render() {

    if (!updateFlag) { return; }

    updateFlag = false;

    Console::setBackgroundColor(BLACK);
    system("cls");
    
    grid.render();
    tetromino->render();

}