using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventSystemManagerGarageScript : MonoBehaviour
{

    [SerializeField] private GameObject confirmationWindow, confBtn;
    [SerializeField] private GameObject warningWindow, warBtn;
    [SerializeField] private GameObject buyCanvas, buyBtn;
    [SerializeField] private GameObject computerCanvas, mainBtn1, mainBtn2;


    bool blocker = false;
    bool blocker2 = false;
    GameObject obj;

    bool wasOn = false;
    //


    [SerializeField] private GameObject btn;
    [SerializeField] private GameObject canvas;
    bool block = true;

    void Update()
    {
        //if none btn selected -> select
        if (computerCanvas.activeSelf)
        {
            
            if(!blocker)
            {
                if (confirmationWindow.activeSelf)
                {
                    GameObject myEventSystem = GameObject.Find("EventSystem");
                    myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null); 
                    confBtn.GetComponent<Button>().Select();
                    blocker = true;
                    obj = confirmationWindow;
                    blocker2 = false;
                }
                else if (warningWindow.activeSelf)
                {
                    GameObject myEventSystem = GameObject.Find("EventSystem");
                    myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
                    warBtn.GetComponent<Button>().Select();
                    blocker = true;
                    obj = warningWindow;
                    blocker2 = false;
                }
            }


            if (obj == null)
            {
                blocker = false;
            }
            else if (!obj.activeSelf)
            {
                blocker = false;
            }


            if (!confirmationWindow.activeSelf&&!warningWindow.activeSelf&& !blocker2&& buyCanvas.activeSelf)
            {
                
                    GameObject myEventSystem = GameObject.Find("EventSystem");
                    myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
                    buyBtn.GetComponent<Button>().Select();
                    blocker2 = true;
            }
            else if(!confirmationWindow.activeSelf && !warningWindow.activeSelf && !blocker2 && !buyCanvas.activeSelf)
            {
                GameObject myEventSystem = GameObject.Find("EventSystem");
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
                if(mainBtn1.activeSelf)
                mainBtn1.GetComponent<Button>().Select();
                else
                mainBtn2.GetComponent<Button>().Select();
                blocker2 = true;
            }

            if(buyCanvas.activeSelf && buyCanvas.activeSelf!= wasOn)
            {
                GameObject myEventSystem = GameObject.Find("EventSystem");
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
                buyBtn.GetComponent<Button>().Select();
                wasOn = buyCanvas.activeSelf;
            }
            else if (!buyCanvas.activeSelf && buyCanvas.activeSelf != wasOn)
            {
                GameObject myEventSystem = GameObject.Find("EventSystem");
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
                if (mainBtn1.activeSelf)
                    mainBtn1.GetComponent<Button>().Select();
                else
                    mainBtn2.GetComponent<Button>().Select();
                wasOn = buyCanvas.activeSelf;
            }

        }
        
        if(canvas.activeSelf)
        {
            var eventSystem = EventSystem.current;
            if (canvas.activeSelf && block)
            {
                block = false;
                eventSystem.SetSelectedGameObject(btn, new BaseEventData(eventSystem));
            }
            else if (!canvas.activeSelf)
            {
                block = true;
            }
        }

        
    }

    
}
