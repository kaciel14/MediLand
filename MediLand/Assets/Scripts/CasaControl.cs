using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CasaControl : MonoBehaviour
{

    public int vidaCasa = 100;
    public int maxVidaCasa = 100;

    private GameObject barra;
    private Image barraImagen;
    // Start is called before the first frame update
    void Start()
    {
        barra = GameObject.Find("barraCasa");
        barraImagen = barra.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dmgCasa(int dmg)
    {
        vidaCasa -= dmg;

        if(vidaCasa >= 88)
        {
            barraImagen.sprite = Resources.Load<Sprite>("UI/lifebar");
        }
        else if (vidaCasa >= 77)
        {
            barraImagen.sprite = Resources.Load<Sprite>("UI/lifebar(1)"); 
        }
        else if (vidaCasa >= 66)
        {
            barraImagen.sprite = Resources.Load<Sprite>("UI/lifebar(2)");
        }
        else if (vidaCasa >= 55)
        {
            barraImagen.sprite = Resources.Load<Sprite>("UI/lifebar(3)");
        }
        else if (vidaCasa >= 44)
        {
            barraImagen.sprite = Resources.Load<Sprite>("UI/lifebar(4)");
        }
        else if (vidaCasa >= 33)
        {
            barraImagen.sprite = Resources.Load<Sprite>("UI/lifebar(5)");
        }
        else if (vidaCasa >= 22)
        {
            barraImagen.sprite = Resources.Load<Sprite>("UI/lifebar(6)");
        }
        else if (vidaCasa >= 11)
        {
            barraImagen.sprite = Resources.Load<Sprite>("UI/lifebar(7)");
        }
        else if(vidaCasa >= 1 )
        {
            barraImagen.sprite = Resources.Load<Sprite>("UI/lifebar(8)");
        }
        else if(vidaCasa <= 0)
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    public void resetCasa()
    {
        vidaCasa = maxVidaCasa;
        dmgCasa(0);
    }
}
