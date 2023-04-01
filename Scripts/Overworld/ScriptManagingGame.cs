using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptManagingGame : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject InGameCanvas;
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private GameObject RestartBtn;
    [SerializeField] private GameObject ControlsPanel;

    [SerializeField] private SpawnPlayer SP;
    private GameObject car;

    [SerializeField] private Transform resetPointTransform;

    [HideInInspector] public bool gamePaused = false;
    [HideInInspector] public bool raceOn = false;
    [SerializeField] private GameObject raceGameObj;
    [SerializeField] private RaceActionPointScript raceScript;


    private void Start()
    {
        car = SP.SendCar();
        resetPointTransform.position = car.transform.position;
        resetPointTransform.rotation = car.transform.rotation;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeMapZoom();
        }

        if (Input.GetKeyDown(KeyCode.M)|| Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCarPosition();
        }

        if(gamePaused)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
        }
    }


    void ChangeMapZoom()
    {
        if(camera.orthographicSize == 200f)
            camera.orthographicSize = 400f;
        else
            camera.orthographicSize = 200f;
    }

    void Pause()
    {
        if(InGameCanvas.activeSelf)
        {
            Time.timeScale = 0.0f;
            InGameCanvas.SetActive(false);
            PauseCanvas.SetActive(true);
            gamePaused = true;
        }
        else
        {
            InGameCanvas.SetActive(true);
            PauseCanvas.SetActive(false);
            gamePaused = false;
            Time.timeScale = 1.0f;
        }
    }

    void ResetCarPosition()
    {
        if(resetPointTransform != null)
        {
            car.transform.position = resetPointTransform.position;
            car.transform.rotation = resetPointTransform.rotation;
        }
    }
    public void SetCurrentCarPosition(Transform point)
    {
        resetPointTransform.position = point.position;
        resetPointTransform.rotation = point.rotation;
        ResetCarPosition();
    }

    public void SetCurrentResetPoint(Transform point)
    {
        resetPointTransform.position = point.position;
        resetPointTransform.rotation = car.transform.rotation;
    }

    public void ContinueBtn()
    {
        if (ControlsPanel.activeSelf) { ControlsPanel.SetActive(false); }
        Pause();
    }

    public void GarageBtn()
    {
        Pause();
        SceneManager.LoadScene("Garage");
    }

    public void ExitBtn()
    {
        Pause();
        SceneManager.LoadScene("Menu");
    }

    public void ControlsBtn()
    {
        if(ControlsPanel.activeSelf)
        {
            ControlsPanel.SetActive(false);
        }
        else
        {
            ControlsPanel.SetActive(true);
        }
    }

    public void RestartButton()
    {
        if (ControlsPanel.activeSelf){  ControlsPanel.SetActive(false); }

        raceScript = raceGameObj.GetComponent<RaceActionPointScript>();
        raceScript.RestartRace();
        Pause();
    }


    public void SetRaceOnTrue(GameObject obj)
    {
        raceOn = true;
        RestartBtn.SetActive(true);
        raceGameObj = obj;
    }

    public void SetRaceOnFalse()
    {
        raceOn = false;
        RestartBtn.SetActive(false);
    }
}
