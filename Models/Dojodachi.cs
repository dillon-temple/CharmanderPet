public class Dojodachi{

    private int happiness;
    private int fullness;
    private int energy;
    private int meals;
    public int Happiness{
        get{
            return happiness;
        }
        set{
            happiness = value;
        }
    }
    public int Energy{
        get{
            return energy;
        }
        set{
            energy = value;
        }
    }
    public int Fullness{
        get{
            return fullness;
        }
        set{
            fullness = value;
        }
    }
    public int Meals{
        get{
            return meals;
        }
        set{
            meals = value;
        }
    }


    public Dojodachi(){
        Happiness = 20;
        Fullness = 20;
        Energy = 50;
        Meals = 3;
    }
}