using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommerceW : MonoBehaviour
{
    private GameObject personaje;

    public GameObject menuArmas;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("prota1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void comprarArma1()
    {
        if(personaje.GetComponent<Inventario>().getCoins() >= 5000)
        {
            personaje.GetComponent<Inventario>().desbloquearArma(1);
            personaje.GetComponent<Inventario>().ganarCoins(-5000);
        } 
    }

    public void comprarArma2()
    {
        if(personaje.GetComponent<Inventario>().getCoins() >= 9000)
        {
            personaje.GetComponent<Inventario>().desbloquearArma(2);
            personaje.GetComponent<Inventario>().ganarCoins(-9000);
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("prota"))
        {
            menuArmas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        menuArmas.SetActive(false);
    }
}
