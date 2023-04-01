using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointColliderForRace : MonoBehaviour
{
    [SerializeField] private RaceActionPointScript RAPS;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            RAPS.addCheckpointStatus(this.gameObject);
        }
    }
}
