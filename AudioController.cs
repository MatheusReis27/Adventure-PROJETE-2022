using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaDeFundoCapa;
    public AudioClip[] musicaDeFundo;
    void Start()
    {
        AudioClip musicaDeFundoDessaFase = musicaDeFundo[0];
        audioSourceMusicaDeFundoCapa.clip = musicaDeFundoDessaFase;
        audioSourceMusicaDeFundoCapa.Play();
    }

   
    void Update()
    {
        
    }
}
