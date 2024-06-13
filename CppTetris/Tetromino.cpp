#include "Tetromino.h"
#include <iostream>

void Tetromino::moveLeft()
{
	position = position + Vector(-1, 0);
}

void Tetromino::moveRight()
{
	position = position + Vector(1, 0);
}

void Tetromino::moveUp()
{
	position = position + Vector(0, -1);
}

void Tetromino::moveDown()
{
	position = position + Vector(0, 1);
}

void Tetromino::rotateAntiClockwise()
{
	rotation = static_cast<Rotation>(static_cast<int>(rotation) - 1);

	if (rotation < Rotation0) 
	{
		rotation = Rotation270;
	}
}

void Tetromino::rotateClockwise()
{
	rotation = static_cast<Rotation>(static_cast<int>(rotation) + 1);

	if (rotation > Rotation270)
	{
		rotation = Rotation0;
	}
}

std::vector<Vector> Tetromino::getPoints()
{
	std::vector<Vector> basePoints;

	basePoints.push_back(position + getBasePoints()[0]);
	basePoints.push_back(position + getBasePoints()[1]);
	basePoints.push_back(position + getBasePoints()[2]);
	basePoints.push_back(position + getBasePoints()[3]);

	return basePoints;
}

void Tetromino::render()
{
	Console::setBackgroundColor(color);

	std::vector<Vector> points = getPoints();

	for (size_t i = 0; i < 4; i++)
	{
		Vector point = Vector(points[i].x * 2, points[i].y);
		Console::setCursorPosition(point);
		std::cout << "  ";
	}
}