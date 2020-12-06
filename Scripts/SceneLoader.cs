using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject cubePrefab;
    public void GoToStartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void GoToMiniGameScene()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void GoToLoadGameScene()
    {
        SceneManager.LoadScene("NewLoadScreen");
    }

    public void GoToSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void GoToStadiumPark()
    {
        SceneManager.LoadScene("StadiumPark");
    }

    public void GoToHotel()
    {
        SceneManager.LoadScene("Hotel");
    }
    public void GoIntoStadium()
    {
        SceneManager.LoadScene("StadiumPark");
    }
    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void GoIntoRedBoxGame()
    {
        SceneManager.LoadScene("RedBoxGame");
    }
    public void GoIntoGreenBoxGame()
    {
        SceneManager.LoadScene("GreenBoxGame");
    }

    public void GoIntoCubeCollectorGame()
    {
        SceneManager.LoadScene("VRGrappleTest");
        
    }
}
