using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagerScript : MonoBehaviour
{

    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject MissionsPanel;
    void Start()
    {
        mainMenuPanel.SetActive(true);
        MissionsPanel.SetActive(false); 
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        mainMenuPanel.SetActive(true);
        MissionsPanel.SetActive(false);
    }
    public void Missions()
    {
        mainMenuPanel.SetActive(false);
        MissionsPanel.SetActive(true);
    }



    public void Quit()
    {
        Application.Quit();
    }
    
}
