using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LevelSelectUI;
    public GameObject MainMenuUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void LevelSelect()
    {
        MainMenuUI.SetActive(false);
        LevelSelectUI.SetActive(true);
    }

    public void BackMainMenu()
    {
        MainMenuUI.SetActive(true);
        LevelSelectUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LevelSelect2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LevelSelect3()
    {
        SceneManager.LoadScene("Level3");
    }
}
