using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public float waitTime = 11f;

    private void Start()
    {
        StartCoroutine(LoadMenu());
    }

    private void Update()
    {
        if(Input.anyKey)
        {
            LoadMenuNow();
        }
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(waitTime);
        LoadMenuNow();
    }

    private void LoadMenuNow()
    {
        SceneManager.LoadScene("Menu");
    }
}
