using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Capa : MonoBehaviour
{   
    public string nomeCena;

    public void LoadScene(string name)
    {
        nomeCena = name;
        StartCoroutine ("Abrir");
    
    }
    
    private IEnumerator Abrir()
    {
        yield return new WaitForSeconds (0.96f);
        SceneManager.LoadScene (nomeCena);
    }
    
}
