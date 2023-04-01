using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageActionPoint : MonoBehaviour
{
    public float rotateSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }

}
