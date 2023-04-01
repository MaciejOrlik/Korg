using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EventSystemManagerMainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject[] btns;
    [SerializeField] private GameObject[] btnsRelative;

    GameObject obj,obj2;
    
    void Update()
    {
        var eventSystem = EventSystem.current;
        bool blocker = true;
        if (obj==null)
        {
            for (int i = 0; i < 8; i++)
            {
                if (btnsRelative[i].activeSelf && blocker)
                {
                    blocker = false;
                    eventSystem.SetSelectedGameObject(btns[i], new BaseEventData(eventSystem));
                    obj = btnsRelative[i];
                }
            }
        }
        else
        {
            if(!obj.activeSelf)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (btnsRelative[i].activeSelf && blocker)
                    {
                        blocker = false;
                        eventSystem.SetSelectedGameObject(btns[i], new BaseEventData(eventSystem));
                        obj = btnsRelative[i];
                    }
                }
            }
        }

    }



}
