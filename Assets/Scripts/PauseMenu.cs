using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseCanvas;
    public bool Paused;
    public bool Pausable;

    void Start()
    {
        PauseCanvas.SetActive(false);
        Paused = false;
        Pausable = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Pausable == true)
        {
            if (Paused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Pause()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
