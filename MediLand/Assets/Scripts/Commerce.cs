using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commerce : MonoBehaviour
{

    private GameObject personaje;

    public GameObject menuPociones;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("prota1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void comprarPocion()
    {
        if(personaje.GetComponent<Inventario>().getCoins() >= 800)
        {
            personaje.GetComponent<Inventario>().aumentarPociones();
            personaje.GetComponent<Inventario>().ganarCoins(-800);
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("prota"))
        {
            menuPociones.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        menuPociones.SetActive(false);
    }
}
