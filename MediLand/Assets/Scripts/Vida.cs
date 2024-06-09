using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    private int vidaActual;
    public Image imagen;
    public GameObject referencia;

    // Start is called before the first frame update
    void Start()
    {

        imagen = GameObject.Find("Image").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        vidaActual = referencia.GetComponent<Combate>().getVidaActual();

        if (vidaActual > 80)
        {
            imagen.sprite = Resources.Load<Sprite>("UI/vida100");
        }
        else if (vidaActual > 60)
        {
            imagen.sprite = Resources.Load<Sprite>("UI/vida80");
        }
        else if (vidaActual > 40)
        {
            imagen.sprite = Resources.Load<Sprite>("UI/vida60");
        }
        else if (vidaActual > 20)
        {
            imagen.sprite = Resources.Load<Sprite>("UI/vida40");
        }else if(vidaActual > 0)
        {
            imagen.sprite = Resources.Load<Sprite>("UI/vida20");
        }
    }
}
