package Home_work.Home_work_5.Services;

import Home_work.Home_work_5.Models.*;
import Home_work.Home_work_5.Models.Exceptions.PositionException;

public class RobotService {

    public static void createRobot(Point position) throws PositionException{
        ValidationService.checkPosition(position);
        if(ValidationService.isFree(position)){
            new Robot(position);
        }else{
            throw new Exceptions().new PositionException("Точка занята");
        }


    }

    
}
