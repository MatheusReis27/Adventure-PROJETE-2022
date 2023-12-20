using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Final : MonoBehaviour
{
    [SerializeField] private AudioSource winSound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            winSound.Play();
            GameController.instance.ShowGameWin();
        }
    }
}
