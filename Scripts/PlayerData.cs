using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Money;
    public bool[] carHave;
    public int[] IndexUpgrade;
    public int howManyCars;
    public int[] carOnSpot;
    public int currentCar;
    public int plotStage;
    public bool[] raceIfDone;

    public PlayerData()
    {
        howManyCars = 1;
        Money = 0;
        IndexUpgrade = new int[] { 0,0,0,0,0};
        carHave = new bool[] { true, false, false, false, false };
        carOnSpot = new int[] { -1, 0, -1 };
        currentCar = 0;
        plotStage = 0;
        raceIfDone = new bool[10] { false, false, false, false, false, false, false, false, false, false };

    }

    public int getMoney() { return Money; }
    public void addMoney(int amount) { Money += amount; }
    public void subtractMoney(int amount) { Money -= amount; }


    public bool haveCar(int carIndx) { return carHave[carIndx]; }
    public void buyCar(int indx) { carHave[indx] = true; IndexUpgrade[indx] = 0; howManyCars += 1; }
    public void sellCar(int indx) { carHave[indx] = false; IndexUpgrade[indx] = 0; howManyCars -= 1; }


    public int getIndexUpgrader(int carIndex) { return IndexUpgrade[carIndex]; }
    public void upgradeCar(int carIndex) { IndexUpgrade[carIndex] +=1; }


    public int getHowManyCars() { return howManyCars; }

    public int getCarOnSpot(int spotIndex) { return carOnSpot[spotIndex]; }

    public void setCarOnSpot(int spot, int car) { carOnSpot[spot] = car; }

    public int getCurrentCar() { return currentCar; }
    public void setCurrentCar(int carIndex) { currentCar = carIndex; }

    public void addPlotStage() { plotStage += 1; }
    public int getPlotStage() { return plotStage; }
    public void resetPlotStage() 
    {
        howManyCars = 1;
        Money = 0;
        IndexUpgrade = new int[] { 0, 0, 0, 0, 0 };
        carHave = new bool[] { true, false, false, false, false };
        carOnSpot = new int[] { -1, 0, -1 };
        currentCar = 0;
        plotStage = 0;
        raceIfDone = new bool[10] { false, false, false, false, false, false, false, false, false, false };
    }

    public void setRaceToDone(int i)
    {
        raceIfDone[i] = true;
    }

    public bool getIfRaceIsDone(int i)
    {
        if (raceIfDone[i])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
