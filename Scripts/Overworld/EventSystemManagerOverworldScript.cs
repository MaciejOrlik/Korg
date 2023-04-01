using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EventSystemManagerOverworldScript : MonoBehaviour
{
    [SerializeField] private GameObject btn;
    [SerializeField] private GameObject canvas;

    bool blocker = true;

    void Update()
    {
        var eventSystem = EventSystem.current;
        if (canvas.activeSelf&&blocker)
        {
            blocker = false;
            eventSystem.SetSelectedGameObject(btn, new BaseEventData(eventSystem));
        }
        else if(!canvas.activeSelf)
        {
            blocker = true;
        }

    }



}
