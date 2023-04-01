using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GarageSceneManager : MonoBehaviour
{
    //UI
    public GameObject img;
    public TMP_Text imgText;
    private string triggerwhat;
    public GameObject computerCanvas;
    private bool computerOn = false;

    public GameObject pauseCanvas;
    //Cars
    public GameObject car0,car1,car2,car3,car4;
    public GameObject[] spot;
    private PlayerData PD;
    //Controller
    public GameObject FirstPersonPlayer;
    private PlayerMovement PM;
    private MouseComponent MC;


    private void Awake()
    {
        spawnCars();
        PM = FirstPersonPlayer.GetComponent<PlayerMovement>();
        MC = FirstPersonPlayer.GetComponentInChildren<MouseComponent>();
    }

    private void Update()
    {
        
        //Button E
        if(img.activeSelf && !pauseCanvas.activeSelf)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (triggerwhat == "CarSpot1")
                {
                    PD.setCurrentCar(PD.getCarOnSpot(0));
                    loadOverworld();
                }
                if (triggerwhat == "CarSpot2")
                {
                    PD.setCurrentCar(PD.getCarOnSpot(1));
                    loadOverworld();
                }
                if (triggerwhat == "CarSpot3")
                {
                    PD.setCurrentCar(PD.getCarOnSpot(2));
                    loadOverworld();
                }
                if (triggerwhat == "Desk")
                {
                    turnOnComputer();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pauseCanvas.activeSelf && !computerOn)
            {
                pauseCanvas.SetActive(true);
                PM.enabled = false;
                MC.enabled = false;
                img.SetActive(false);
            }
            else if(!computerOn)
            {
                pauseCanvas.SetActive(false);
                PM.enabled = true;
                MC.enabled = true;

            }
        }

        if (pauseCanvas.activeSelf || computerOn)
        {
            PM.enabled = false;
            MC.enabled = false;
        }
        else
        {
            PM.enabled = true;
            MC.enabled = true;
        }
    }


    public void turnOnComputer()
    {
        computerCanvas.SetActive(true);
        PM.enabled = false;
        computerOn = true;
        MC.enabled = false;
    }

    public void turnOffComputer()
    {
        PM.enabled = true;
        computerOn = false;
        MC.enabled = true;
    }
    public void TriggerActive(string triggersWhat)
    {
        triggerwhat = triggersWhat;

        if (triggerwhat == "CarSpot1")
        {
            imgText.text = "Press (E) to leave garage";
        }
        else if (triggerwhat == "CarSpot2")
        {
            imgText.text = "Press (E) to leave garage";
        }
        else if (triggerwhat == "CarSpot3")
        {
            imgText.text = "Press (E) to leave garage";
        }
        else if (triggerwhat == "Desk")
        {
            imgText.text = "Press (E) to open the computer";
        }

        
        img.SetActive(true);
    }

    public void TriggerDisActive(string triggersWhat)
    {
        img.SetActive(false);
    }

    public void loadOverworld()
    {
        SaveData.Save(PD);
        SceneManager.LoadScene("Overworld");
    }

    public void spawnCars()
    {
        for (int i = 0; i < 3; i++)
        {
            PD = SaveData.Load();
            spot[i].SetActive(true);
            switch (PD.getCarOnSpot(i))
            {
                case 0:
                    Instantiate(car0, spot[i].transform.position, transform.rotation * Quaternion.Euler(0, -90, 0));
                    break;
                case 1:
                    Instantiate(car1, spot[i].transform.position, transform.rotation * Quaternion.Euler(0, -90, 0));
                    break;
                case 2:
                    Instantiate(car2, spot[i].transform.position, transform.rotation * Quaternion.Euler(0, -90, 0));
                    break;
                case 3:
                    Instantiate(car3, spot[i].transform.position, transform.rotation * Quaternion.Euler(0, -90, 0));
                    break;
                case 4:
                    Instantiate(car4, spot[i].transform.position, transform.rotation * Quaternion.Euler(0, -90, 0));
                    break;
                default:
                    spot[i].SetActive(false);
                    break;
            }
        }
    }

    public void despawnCars()
    {
        var cars = GameObject.FindGameObjectsWithTag("Car");
        for(int i=0;i<cars.Length;i++)
        {
            Destroy(cars[i]);
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
