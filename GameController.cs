using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public static GameController instance;
    public GameObject gameOver;
    public GameObject gameWin;
    [SerializeField] private AudioSource loseSound;
    

    void Start()
    {
        instance = this;

    }

    void Update ()
    {
        
    }
    
    
     

    public void UpdateScoreText()
    {
       scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
          loseSound.Play();
          gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
       SceneManager.LoadScene(lvlName);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowGameWin()
    {
          gameWin.SetActive(true);
    }

}
