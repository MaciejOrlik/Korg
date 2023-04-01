using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnPlayer : MonoBehaviour
{
    private PlayerData PD;
    
    private GameObject car;
    private UnityStandardAssets.Vehicles.Car.CarController CC;
    public GameObject[] cars;

    public float carRotation= 0f;

    public CinemachineFreeLook cinemachine;
    public MiniMapCamera miniMapCamera;
    public CanvasManager canvasManager;
    public GameObject carArrow;

    public Transform spawnTransform;


    void Awake()
    {
        PD = SaveData.Load();
        if (spawnTransform == null) spawnTransform = this.transform;
        setUpPlayer();
    }

    void Update()
    {
        carArrow.transform.position = new Vector3(car.transform.position.x, 116f, car.transform.position.z);
        carArrow.transform.rotation = Quaternion.Euler(90f, 0f, -car.transform.rotation.eulerAngles.y);
    }

    public void setUpPlayer()
    {
        int carIndex = PD.getCurrentCar();
        int carUpgrade = PD.getIndexUpgrader(carIndex);
        
        car = Instantiate(cars[carIndex], spawnTransform.position, spawnTransform.rotation * Quaternion.Euler(0, carRotation, 0));
        cinemachine.LookAt = car.transform;
        cinemachine.Follow = car.transform;
        miniMapCamera.setTarget(car.transform);
        CC = car.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();
        canvasManager.setCarScript(CC);
        CC.setMaxSpeed(100 + (carIndex*10) + (carUpgrade*5));
        CC.setAcceleration(1000 + (carIndex * 300) + (carUpgrade * 150));
    }
    
    public GameObject SendCar()
    {
        return car;
    }

    

    
}
