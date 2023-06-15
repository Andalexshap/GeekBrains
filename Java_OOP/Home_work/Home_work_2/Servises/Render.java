package Home_work.Home_work_2.Servises;

import Home_work.Home_work_2.Interfaces.HasHealthPoint;
import Home_work.Home_work_2.Interfaces.Tiredness;

public class Render {
    String symbol;
    int scaleSise;
    int maxScaleSise;

    public Render(String symbol, int scaleSise, int maxScaleSise) {
        this.symbol = symbol;
        this.scaleSise = scaleSise;
        if (maxScaleSise < 49 + scaleSise) {
            this.maxScaleSise = 49 + scaleSise;

        } else {
            this.maxScaleSise = maxScaleSise;
        }
    }

    public Render() {
        this("#", 20, 50);
    }

    public void render(Object object) {
        if (object instanceof HasHealthPoint) {
            HasHealthPoint hasHealthPointObj = (HasHealthPoint) object;
            int currentHealthPoint = hasHealthPointObj.getCurrentHealthPoint();
            int maxHealthPoint = hasHealthPointObj.getMaxHealthPoint();
            printValuePoint(object.getClass().getSimpleName(), "HealthPoint", currentHealthPoint, maxHealthPoint);
        }
        if (object instanceof Tiredness) {
            Tiredness tirednessObj = (Tiredness) object;
            int currentTiredness = tirednessObj.getCurrentEnergy();
            int maxTiredness = tirednessObj.getMaxEnergy();
            printValuePoint(object.getClass().getSimpleName(), "Tiredness", currentTiredness, maxTiredness);
        }

        System.out.println();

    }

    private void printValuePoint(String nameOfObject, String value, int currentValuePoint, int maxValuePoint) {
        String color;

        if (currentValuePoint <= maxValuePoint / 4) {
            color = TextColor.getColor("red");
        } else if (currentValuePoint <= maxValuePoint / 2) {
            color = TextColor.getColor("yellow");
        } else {
            color = TextColor.getColor("green");
        }

        String info = nameOfObject + " [" + value + " :" + color + currentValuePoint + TextColor.reset() + "]";
        if (currentValuePoint >= 0) {
            int repeatSymbolCount = currentValuePoint * scaleSise / maxValuePoint;
            if (repeatSymbolCount < 1) {
                repeatSymbolCount = 1;
            }
            String scale = "[" + color + symbol.repeat(repeatSymbolCount) + " ".repeat(scaleSise - repeatSymbolCount)
                    + TextColor.reset() + "]";

            System.out.println(info + " ".repeat(maxScaleSise - info.length() - scale.length()) + scale);
        }

    }
}
