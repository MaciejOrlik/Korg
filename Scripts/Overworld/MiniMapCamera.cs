using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    private Transform target;
    public Vector3 offset = new Vector3( 0f, 100f, 0f );
    public GameObject mainCamera;

    
    void Update()
    {
        transform.position = target.position + offset;
        transform.eulerAngles = new Vector3(90, mainCamera.transform.rotation.y ,0);
        transform.rotation = Quaternion.Euler(90f, mainCamera.transform.rotation.eulerAngles.y, 0f );
    }

    public void setTarget(Transform _target)
    {
        target = _target;
    }
}
