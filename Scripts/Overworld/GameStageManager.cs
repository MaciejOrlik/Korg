using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageManager : MonoBehaviour
{
    private PlayerData PD;

    [SerializeField] private SpawnPlayer SP;
    [SerializeField] private Transform newSapwnPoint;
    [SerializeField] private GameObject garageAP, GarageBTN;
    [SerializeField] private GameObject[] race;

    void Awake()
    {
        PD = SaveData.Load();
        //If begginging of plot
        if (PD.getPlotStage() == 1)
        {
            SP.spawnTransform = newSapwnPoint;
            StartRace(0);
            GarageBTN.SetActive(false);
        }
        else if (PD.getPlotStage() == 2)
        {
            SP.spawnTransform = newSapwnPoint;
            for (int j = 0; j < 10; j++)
            {
                race[j].SetActive(false);
                GarageBTN.SetActive(false);
            }
        }
        else if (PD.getPlotStage() < 8)
        {
            for (int i = 0; i < 10; i++)
            {
                if (PD.getIfRaceIsDone(i))
                {
                    TurnOffOneRace(i);
                }
            }
            TurnOffOneRace(9);
        }
        else if (PD.getPlotStage() == 8)
        {
            foreach (GameObject r in race)
            {
                r.SetActive(false);
            }
            race[9].SetActive(true);
        }
        else if (PD.getPlotStage() > 7)
        {
            Debug.Log("GameDone");
        }
    }
   

    public void StartRace(int i)
    {
        for(int j=0;j<10;j++ )
        {
            if (j != i) { race[j].SetActive(false); }
        }
        garageAP.SetActive(false);
    }
    

    public void TurnOffOneRace(int i)
    {
        race[i].SetActive(false);
    }

}
