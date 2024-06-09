using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyControl : MonoBehaviour
{
    public int vidaMax = 100;

    public int vidaActual = 100;

    public int dmg = 20;
    public int dmgCasa = 10;
    public float countMax = 1000.0f;
    public float count = 1000;

    public int coins = 200;

    public LayerMask mascara;
    public LayerMask mascaraCasa;

    private GameObject jugador;

    private GameObject casa;

    private GameObject wave;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("prota1");
        casa = GameObject.Find("casa");
        wave = GameObject.Find("WaveControl");
    }

    // Update is called once per frame
    void Update()
    {
        if(count == countMax)
        {
            try
            {
                hacerDmg();
            }
            catch (NullReferenceException e)
            {

            }

            try
            {
                hacerDmgCasa();
            }
            catch(NullReferenceException e)
            {

            }

            count = 0;
        }
        count++;
    }

    public void recibeDmg(int dmg)
    {
        vidaActual -= dmg;

        if (vidaActual <= 0)
        {
            Destroy(gameObject);
            jugador.GetComponent<Inventario>().ganarCoins(200);
            wave.GetComponent<WaveControl>().derrotados++;
        }
    }

    public void hacerDmg()
    {
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(gameObject.transform.position, 1, mascara);

        foreach (Collider2D enemigo in enemigos)
        {
            enemigo.GetComponent<Combate>().herir(dmg);
            Debug.Log("Recibes daño");
        }
    }


    public void hacerDmgCasa()
    {
        Collider2D[] colisiones = Physics2D.OverlapCircleAll(gameObject.transform.position, 2.5f, mascaraCasa);

        foreach (Collider2D colision in colisiones)
        {
            casa.GetComponent<CasaControl>().dmgCasa(dmgCasa);
            Debug.Log("Recibe daño la casa ");
        }
    }

}
