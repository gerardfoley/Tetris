#pragma once
class Vector
{
public:

	Vector() 
	{
		x = 0;
		y = 0;
	}

	Vector(int x, int y)
	{
		Vector::x = x;
		Vector::y = y;
	}

	int x;
	int y;

	Vector operator+(Vector const& obj)
	{
		return Vector(x + obj.x, y + obj.y);
	}
};