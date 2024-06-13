#pragma once
#include <windows.h>
#include "Vector.h"

constexpr auto BLACK = 0;
#define BACKGROUND_YELLOW BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_INTENSITY
#define BACKGROUND_DARK_YELLOW BACKGROUND_RED | BACKGROUND_GREEN
#define BACKGROUND_MAGENTA BACKGROUND_RED | BACKGROUND_BLUE | BACKGROUND_INTENSITY
#define BACKGROUND_CYAN BACKGROUND_GREEN | BACKGROUND_BLUE | BACKGROUND_INTENSITY
#define BACKGROUND_LIME BACKGROUND_GREEN | BACKGROUND_INTENSITY
#define BACKGROUND_LIGHT_RED BACKGROUND_RED | BACKGROUND_INTENSITY

class Console
{
public:
	static void setCursorPosition(int x, int y);
	static void setCursorPosition(Vector point);
	static void setBackgroundColor(WORD wAttributes);
	static void hideCursor();
};