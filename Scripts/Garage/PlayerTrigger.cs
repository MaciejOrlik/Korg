using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    public GarageSceneManager gsm;
    public string triggersWhat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gsm.TriggerActive(triggersWhat);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gsm.TriggerDisActive(triggersWhat);
        }
    }
}
