using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;


public class ComputerManager : MonoBehaviour
{
    private PlayerData PD;
    public GarageSceneManager GSM;

    public TMP_Text moneyDisplay;
    public GameObject[] logoLeft, logoMiddle, logoRight;
    public GameObject[] btnLeft, btnMiddle, btnRight;
    public GameObject buyCanvas;
    public GameObject computerCanvas;

    public GameObject warningWindow;
    public Text warningWindowText;

    [Header("Confirmation")]
    public GameObject confirmationWindow;
    public Text confirmationWindowText;
    public Button yesBtn;
    public Button noBtn;

    private string[] carName = { "BMW M5", "Toyota GR Supra", "Lamborghini Aventador", "Bugatti Chiron Pur Sport", "Jesko Koenigsegg" };

    private void Awake()
    {
        PD = SaveData.Load();
        setAll();
    }

    private void Update()
    {
        //managing Escape btn
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(confirmationWindow.activeSelf)
            {
                confirmationWindow.SetActive(false);
            }
            else if(buyCanvas.activeSelf)
            {
                buyCanvas.SetActive(false);
            }
            else if(computerCanvas.activeSelf)
            {
                SaveData.Save(PD);
                GSM.despawnCars();
                GSM.spawnCars();
                GSM.turnOffComputer();
                computerCanvas.SetActive(false);
            }
        }
    }

    private void setAll()
    {
        setUpLogos();
        setUpButtons();
        setMoney();
    }

    private void setUpLogos()
    {
        for(int j=0;j<6;j++)
        {
            logoLeft[j].SetActive(false);
            logoMiddle[j].SetActive(false);
            logoRight[j].SetActive(false);
        }

        for(int i=0;i<3;i++)
        {
            
            if(PD.getCarOnSpot(i)==-1) //no car
            {
                if(i==0)
                    logoLeft[0].SetActive(true);
                else if(i==1)
                    logoMiddle[0].SetActive(true);
                else
                    logoRight[0].SetActive(true);
            }


            else if(PD.getCarOnSpot(i) == 0) //bmw
            {
                if (i == 0)
                    logoLeft[1].SetActive(true);
                else if (i == 1)
                    logoMiddle[1].SetActive(true);
                else
                    logoRight[1].SetActive(true);
            }


            else if (PD.getCarOnSpot(i) == 1) //supra
            {
                if (i == 0)
                    logoLeft[2].SetActive(true);
                else if (i == 1)
                    logoMiddle[2].SetActive(true);
                else
                    logoRight[2].SetActive(true);
            }


            else if (PD.getCarOnSpot(i) == 2) //lambo
            {
                if (i == 0)
                    logoLeft[3].SetActive(true);
                else if (i == 1)
                    logoMiddle[3].SetActive(true);
                else
                    logoRight[3].SetActive(true);
            }


            else if (PD.getCarOnSpot(i) == 3) //bugatti
            {
                if (i == 0)
                    logoLeft[4].SetActive(true);
                else if (i == 1)
                    logoMiddle[4].SetActive(true);
                else
                    logoRight[4].SetActive(true);
            }


            else if (PD.getCarOnSpot(i) == 4) //jesko
            {
                if (i == 0)
                    logoLeft[5].SetActive(true);
                else if (i == 1)
                    logoMiddle[5].SetActive(true);
                else
                    logoRight[5].SetActive(true);
            }
        }
    }

    private void setUpButtons()
    {
        
        if (PD.getCarOnSpot(0) == -1)
        {
            btnLeft[0].SetActive(false);
            btnLeft[1].SetActive(false);
            btnLeft[2].SetActive(true);
        }
        else
        {
            btnLeft[0].SetActive(true);
            btnLeft[1].SetActive(true);
            btnLeft[2].SetActive(false);
        }
        if (PD.getCarOnSpot(1) == -1)
        {
            btnMiddle[0].SetActive(false);
            btnMiddle[1].SetActive(false);
            btnMiddle[2].SetActive(true);
        }
        else
        {
            btnMiddle[0].SetActive(true);
            btnMiddle[1].SetActive(true);
            btnMiddle[2].SetActive(false);
        }
        if (PD.getCarOnSpot(2) == -1)
        {
            btnRight[0].SetActive(false);
            btnRight[1].SetActive(false);
            btnRight[2].SetActive(true);
        }
        else
        {
            btnRight[0].SetActive(true);
            btnRight[1].SetActive(true);
            btnRight[2].SetActive(false);
        }
    }

    private void setMoney()
    {
        moneyDisplay.text = PD.getMoney().ToString();
    }

    //btns functions

    public void tune(int carSpot)
    {
        int carIndex = PD.getCarOnSpot(carSpot);
        int carUpgrade = PD.getIndexUpgrader(carIndex);
        int price = ((2 * carUpgrade) + 2 + 4 * (carIndex + 1))*4;

        if (carUpgrade > 2)
        {
            warningWindowText.text = "This car is fully upgraded.";
            warningWindow.SetActive(true);
        }
        else if(PD.getMoney()<price)
        {
            warningWindowText.text = "You do not have enough money.";
            warningWindow.SetActive(true);
        }
        else
        {
           askConfirmation("Tune " + carName[PD.getCarOnSpot(carSpot)] + " for " + price.ToString() + " coins?"
            , () =>
            {
                PD.subtractMoney(price);
                PD.upgradeCar(carIndex);
                setAll();
                confirmationWindow.SetActive(false);
                yesBtn.onClick.RemoveAllListeners();
            }
            , () =>
            {
                confirmationWindow.SetActive(false);
                yesBtn.onClick.RemoveAllListeners();
            }
            );
        }
    }
   
    public void sell(int carSpot)
    {
        
        int hasHowManyCars = 0;

        for(int i =0;i<3;i++)
        {
            if (PD.getCarOnSpot(i) != -1)
            {
                hasHowManyCars += 1;
            }
        }

        if(hasHowManyCars<2)
        {
            warningWindowText.text = "You can not sell the only car you have.";
            warningWindow.SetActive(true);
        }
        else
        {
            int returneMoney = (PD.getCarOnSpot(carSpot) + 1) * 20;

            askConfirmation("Sell " + carName[PD.getCarOnSpot(carSpot)] + " for " + returneMoney.ToString() + " coins?"
            , () =>
            {
                PD.setCarOnSpot(carSpot, -1);
                PD.addMoney(returneMoney);
                setAll();
                confirmationWindow.SetActive(false);
                yesBtn.onClick.RemoveAllListeners();
            }
            , () =>
            {
                confirmationWindow.SetActive(false);
                yesBtn.onClick.RemoveAllListeners();
            }
            );

            
        }
    }

    public void buy()
    {
        buyCanvas.SetActive(true);
    }

    public void buy(int carIndex)
    {
        bool hasThisCar = false;
        
        for(int i=0; i<3; i++)
        {
            if(PD.getCarOnSpot(i) == carIndex)
            {
                hasThisCar = true;
            }
        }
        int price = (carIndex * 35) + 60;

        if (hasThisCar==true)
        {
            warningWindowText.text = "You have this car already.";
            warningWindow.SetActive(true);
        }
        else if (PD.getMoney() < price)
        {
            warningWindowText.text = "You do not have enough money.";
            warningWindow.SetActive(true);
        }
        else
        {
            askConfirmation("Buy " + carName[carIndex] + " for " + price.ToString() + " coins?"
            , () =>
            {
                PD.subtractMoney(price);

                int spot = 0;
                bool emptySpot = false;

                do
                {
                    if (PD.getCarOnSpot(spot) == -1)
                        emptySpot = true;
                    else
                        spot++;

                } while (emptySpot == false);

                PD.setCarOnSpot(spot, carIndex);
                setAll();
                confirmationWindow.SetActive(false);
                yesBtn.onClick.RemoveAllListeners();
                buyCanvas.SetActive(false);
            }
            , () =>
            {
                confirmationWindow.SetActive(false);
                yesBtn.onClick.RemoveAllListeners();
            }
            );
        }
    }

    public void disactiveWarning()
    {
        warningWindow.SetActive(false);
    }

    //confirmation window

    public void askConfirmation(string text, Action  yesAction, Action noAction)
    {
        confirmationWindowText.text = text;
        yesBtn.onClick.AddListener(new UnityEngine.Events.UnityAction(yesAction));
        noBtn.onClick.AddListener(new UnityEngine.Events.UnityAction(noAction));
        confirmationWindow.SetActive(true);
    }

}
