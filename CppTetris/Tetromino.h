#pragma once

#include <Windows.h>
#include <vector>
#include "Vector.h"
#include "Rotation.h"
#include "Console.h"

class Tetromino
{
public:
	Vector position;
	Rotation rotation = Rotation0;
	WORD color = BLACK;
	void moveLeft();
	void moveRight();
	void moveUp();
	void moveDown();
	void rotateAntiClockwise();
	void rotateClockwise();
	virtual std::vector<Vector> getBasePoints() = 0;
	std::vector<Vector> getPoints();
	void render();
};