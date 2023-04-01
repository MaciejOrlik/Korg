using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneChanger : MonoBehaviour
{
    private PlayerData PD;
    [SerializeField] private GameObject enterGarage;
    private void Start()
    {
        PD = SaveData.Load();
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(Input.GetKey(KeyCode.E))
        {
            if (PD.getPlotStage() == 2)
                SceneManager.LoadScene("Plot");
            else
                SceneManager.LoadScene("Garage");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        enterGarage.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        enterGarage.SetActive(false);
    }
}
