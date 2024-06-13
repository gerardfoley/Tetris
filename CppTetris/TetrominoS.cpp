#include "TetrominoS.h"


TetrominoS::TetrominoS() {
    color = BACKGROUND_LIME;
}

std::vector<Vector> TetrominoS::getBasePoints() {

    std::vector<Vector> basePoints;
    switch (rotation)
    {

    case Rotation::Rotation0:

        basePoints.push_back(Vector(0, 2));
        basePoints.push_back(Vector(1, 1));
        basePoints.push_back(Vector(1, 2));
        basePoints.push_back(Vector(2, 1));
        break;

    case Rotation::Rotation90:

        basePoints.push_back(Vector(0, 0));
        basePoints.push_back(Vector(0, 1));
        basePoints.push_back(Vector(1, 1));
        basePoints.push_back(Vector(1, 2));
        break;

    case Rotation::Rotation180:

        basePoints.push_back(Vector(0, 1));
        basePoints.push_back(Vector(1, 1));
        basePoints.push_back(Vector(1, 0));
        basePoints.push_back(Vector(2, 0));
        break;

    case Rotation::Rotation270:

        basePoints.push_back(Vector(1, 0));
        basePoints.push_back(Vector(1, 1));
        basePoints.push_back(Vector(2, 1));
        basePoints.push_back(Vector(2, 2));
        break;
    }
    return basePoints;

}