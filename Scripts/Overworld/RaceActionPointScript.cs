using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RaceActionPointScript : MonoBehaviour
{
    [SerializeField] private ScriptManagingGame SMG;
    [SerializeField] private GameObject raceCanvasGameObject;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameStageManager GSM;

    [SerializeField] private GameObject timerObj;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timeForRace = 600;
    [SerializeField] private int raceNr;

    [SerializeField] private GameObject[] raceSecurityToTurnOnForRace;
    //musi byæ 5
    [SerializeField] private GameObject[] raceCheckpoints;
    private int checkpointStatus = 0;

    private float time = 1, min = 0, sec =0;

    private PlayerData PD;

    private void Start()
    {
        PD = SaveData.Load();
    }



    private void Update()
    {
        time -= Time.deltaTime;
        sec = time % 60;
        min = (time - sec) / 60;
        if(timerObj.activeSelf)
        {
            timerText.text = min.ToString()+":"+sec.ToString("00.00");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            raceCanvasGameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E)&&raceCanvasGameObject.activeSelf)
        {
            StartRace();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            raceCanvasGameObject.SetActive(false);
        }
    }



    private void StartRace()
    {
        SMG.SetRaceOnTrue(this.gameObject);
        foreach( GameObject obj in raceSecurityToTurnOnForRace){ obj.SetActive(true);}
        GSM.StartRace(raceNr);
        SetRace();
    }


    public void RestartRace()
    {
        SetRace();
    }


    public void EndRace()
    {
        if (time > 0.0f)
        {
            PD.addMoney(120);
            PD.setRaceToDone(raceNr);
            SaveData.Save(PD);
            if (PD.getPlotStage() < 9)
                SceneManager.LoadScene("Plot");
            else
                SceneManager.LoadScene("Garage");
        }
        else
        {
            RestartRace();
        }
    }


    private void SetRace()
    {
        checkpointStatus = 0;
        foreach(GameObject obj in raceCheckpoints) { obj.SetActive(true); }

        spawnPoint.transform.position = this.transform.position;
        spawnPoint.transform.rotation = this.transform.rotation;
        SMG.SetCurrentCarPosition(spawnPoint.transform);

        timerObj.SetActive(true);
        time = timeForRace;
    }
     public void addCheckpointStatus(GameObject obj)
    {
        checkpointStatus += 1;
        obj.SetActive(false);
        if(checkpointStatus==5)
        {
            EndRace();
        }
    }
    
}
