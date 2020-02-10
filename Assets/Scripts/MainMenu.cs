using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string _levelName;
    public string _ControlsName;
    public string _InstructionsName;
    public string _CreditsName;
    public string _MenuName;

    public GameObject MainCanvas;
    public GameObject VideoCanvas;
    public GameObject VideoCanvas2;

    public void _PlayGame()
    {
        SceneManager.LoadScene(_levelName);
    }

    public void _Controls()
    {
        SceneManager.LoadScene(_ControlsName);
    }

    public void _Intructions()
    {
        SceneManager.LoadScene(_InstructionsName);
    }

    public void _Video()
    {
        MainCanvas.SetActive(false);
        VideoCanvas.SetActive(true);
    }

    public void _Video2()
    {
        MainCanvas.SetActive(false);
        VideoCanvas2.SetActive(true);
    }

    public void _VideoBACK()
    {
        MainCanvas.SetActive(true);
        VideoCanvas.SetActive(false);
    }

    public void _VideoBACK2()
    {
        MainCanvas.SetActive(true);
        VideoCanvas2.SetActive(false);
    }

    public void _Credits()
    {
        SceneManager.LoadScene(_CreditsName);
    }

    public void _Menu()
    {
        SceneManager.LoadScene(_MenuName);
    }

    public void _QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
