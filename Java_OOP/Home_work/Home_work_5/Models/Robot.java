package Home_work.Home_work_5.Models;

import Home_work.Home_work_5.Models.Exceptions.PositionException;
import Home_work.Home_work_5.Services.*;

public class Robot {
    private static long counterId = 1;
    private long id;

    private Point position;
    private Direction direction;

    public Robot(Point position) {
        this.id = counterId++;
        this.position = position;
        this.direction = Direction.TOP;
        RobotMap.addRobot(this);
    }

    public long getId() {
        return id;
    }

    public Point getPosition() {
        return position;
    }

    public Direction getDirection() {
        return direction;
    }

    public void move() throws PositionException {
        Point newPosition = switch (direction) {
            case TOP -> new Point(position.getX() - 1, position.getY());
            case RIGHT -> new Point(position.getX(), position.getY() + 1);
            case BOTTOM -> new Point(position.getX() + 1, position.getY());
            case LEFT -> new Point(position.getX(), position.getY() - 1);
        };
        ValidationService.checkPosition(newPosition);

        position = newPosition;
    }

    public void changeDirection(Direction direction) {
        this.direction = direction;
    }

    @Override
    public String toString() {
        return String.format("ID = [%s] Позиция = %s", String.valueOf(id), position.toString());
    }
}
