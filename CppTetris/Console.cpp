#include "Console.h"

void Console::setCursorPosition(int x, int y) {
    HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
    COORD pos = { x, y };
    SetConsoleCursorPosition(hConsole, pos);
}

void Console::setCursorPosition(Vector point) {
    Console::setCursorPosition(point.x, point.y);
}

void Console::setBackgroundColor(WORD wAttributes) {
    HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
    SetConsoleTextAttribute(hConsole, wAttributes);
}

void Console::hideCursor() {
    CONSOLE_CURSOR_INFO cursorInfo{};
    cursorInfo.dwSize = 100;
    cursorInfo.bVisible = FALSE;
    SetConsoleCursorInfo(GetStdHandle(STD_OUTPUT_HANDLE), &cursorInfo);
}