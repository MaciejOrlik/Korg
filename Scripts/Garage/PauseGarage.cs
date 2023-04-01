using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGarage : MonoBehaviour
{
    public void exitBtn()
    {
        SceneManager.LoadScene("Menu");
    }
}
