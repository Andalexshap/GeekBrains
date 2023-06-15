package Home_work.Home_work_5.Services;

import Home_work.Home_work_5.Models.*;
import Home_work.Home_work_5.Models.Exceptions.PositionException;
import Home_work.Home_work_5.View.Views;

public class ValidationService {

    public static void checkPosition(Point position) throws PositionException {
        var sizeMap = RobotMap.getRobotMapSize();
        if (position.getX() < 0 || position.getY() < 0 || position.getX() > sizeMap[0]
                || position.getY() > sizeMap[1]) {
            throw new Exceptions().new PositionException("Некорректное значение точки: " + position);
        }
        if (!isFree(position)) {
            throw new Exceptions().new PositionException("Точка " + position + " занята!");
        }
    }

    public static boolean isFree(Point position) {
        var robots = RobotMap.getRobots();
        for (Robot robot : robots) {
            if (robot.getPosition().equals(position)) {
                return false;
            }
        }
        return true;
    }

    public static void validateCommand(String message) throws Exception {
        var command = message.split(" ");
        int id;
        Robot robot = null;
        var robots = RobotMap.getRobots();
        switch (command[0].toLowerCase()) {
            case "create-map":
                try {
                    new RobotMap(Integer.parseInt(command[1]), Integer.parseInt(command[2]));
                } catch (Exception e) {
                    throw new Exceptions().new CreateException("Ошибка создания карты. Попробуйте заново!");
                }
                Views.displayMap();
                break;
            case "create-robot":
                try {
                    RobotService.createRobot(new Point(Integer.parseInt(command[1]), Integer.parseInt(command[2])));
                } catch (Exception e) {
                    throw e;
                }
                break;
            case "move-robot":
                try {
                    id = Integer.parseInt(command[1]);
                } catch (Exception e) {
                    throw new Exceptions().new CreateException("Неверный id. Попробуйте еще раз!");
                }
                for (Robot r : robots) {
                    if (r.getId() == id) {
                        robot = r;
                    }
                }
                if (robot != null) {
                    robot.move();
                } else {
                    System.out.println("Робот с id = " + id + " не найден!");
                }
                break;
            case "change-direction":
                try {
                    id = Integer.parseInt(command[1]);
                } catch (Exception e) {
                    throw new Exceptions().new CreateException("Неверный id. Попробуйте еще раз!");
                }
                for (Robot r : robots) {
                    if (r.getId() == id) {
                        robot = r;
                    }
                }
                if (robot != null) {
                    switch (command[2].toUpperCase()) {
                        case "LEFT":
                            robot.changeDirection(Direction.LEFT);
                            break;
                        case "RIGHT":
                            robot.changeDirection(Direction.RIGHT);
                            break;
                        case "BOTTOM":
                            robot.changeDirection(Direction.BOTTOM);
                            break;
                        case "TOP":
                            robot.changeDirection(Direction.TOP);
                            break;
                        default:
                            throw new Exceptions().new CreateException(
                                    "Направление не распознано. Попробуйте еще раз!");
                    }
                } else {
                    System.out.println("Робот с id = " + id + " не найден!");
                }
                break;
            default:
                throw new Exceptions().new CreateException(
                        "Команда отсутствует. Попробуйте еще раз!");
        }
    }
}