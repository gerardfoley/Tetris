#include "TetrominoI.h"


TetrominoI::TetrominoI() {
    color = BACKGROUND_CYAN;
}

std::vector<Vector> TetrominoI::getBasePoints() {

    std::vector<Vector> basePoints;
    switch (rotation)
    {

    case Rotation::Rotation0:
    case Rotation::Rotation180:

        basePoints.push_back(Vector(1, 0));
        basePoints.push_back(Vector(1, 1));
        basePoints.push_back(Vector(1, 2));
        basePoints.push_back(Vector(1, 3));
        break;

    case Rotation::Rotation90:
    case Rotation::Rotation270:

        basePoints.push_back(Vector(0, 1));
        basePoints.push_back(Vector(1, 1));
        basePoints.push_back(Vector(2, 1));
        basePoints.push_back(Vector(3, 1));
        break;
    }
    return basePoints;

}