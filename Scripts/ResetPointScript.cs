using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPointScript : MonoBehaviour
{
    [SerializeField] private ScriptManagingGame SMG;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SMG.SetCurrentResetPoint(this.transform);
        }
    }
}
