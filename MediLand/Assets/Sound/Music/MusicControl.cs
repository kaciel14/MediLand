using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void apagarMusica()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void resetMusica()
    {
        GetComponent<AudioSource>().Play();
    }
}
