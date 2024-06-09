using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combate : MonoBehaviour
{
    public int vidaMax = 100;
    private int vida;
    // Start is called before the first frame update
    void Start()
    {
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void herir(int dmg)
    {
        vida -= dmg;
        if(vida <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("StartMenu");
        }
    }

    public int getVidaActual()
    {
        return vida;
    }

    public void curar()
    {
        vida += 20;
    }
}
