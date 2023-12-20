using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject mapsPanel;
    

    public void QuitGame()
    {
         
         //Jogo Compilado
         Application.Quit();
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
    }
     
    public void BackToMenu()
    {
        optionsPanel.SetActive(false);
    }

    public void ShowMaps()
    {
        mapsPanel.SetActive(true);
    }  
     
    public void CloseMaps()
    {
        mapsPanel.SetActive(false);
    }
    public void Forest()
    {
        SceneManager.LoadScene("Forest");
    }
    public void Halloween()
    {
        SceneManager.LoadScene("Halloween");
    }
    public void Beach()
    {
        SceneManager.LoadScene("Beach");
    }
    public void FairyTale()
    {
        SceneManager.LoadScene("FairyTale");
    }
    public void Winter()
    {
        SceneManager.LoadScene("Winter");
    }
    public void Desert()
    {
        SceneManager.LoadScene("Desert");
    }
   
}
