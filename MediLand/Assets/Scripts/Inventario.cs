using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public int numPocionesSalud;
    private int vida;

    private int[] armas = new int[3];

    private int armaActual = 0;

    private PlayerAtck personaje;
    private Movement movimiento;

    public GameObject espada;

    private SpriteRenderer imagen;

    public Text contador;

    public int coins = 0;

    public Text textoMonedas;

    // Start is called before the first frame update
    void Start()
    {
        imagen = espada.GetComponent<SpriteRenderer>();

        personaje = GameObject.Find("prota1").GetComponent<PlayerAtck>();
        movimiento = personaje.GetComponent<Movement>();

        armas[0] = 0;
        armas[1] = 0;
        armas[2] = 0;

        armaActual = armas[0];

        cambiarArma();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            usarPocionVida();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            armaActual = armas[0];
            cambiarArma();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            armaActual = armas[1];
            cambiarArma();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            armaActual = armas[2];
            cambiarArma();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            aumentarPociones();
        }
    }

    public void usarPocionVida()
    {
        vida = GetComponent<Combate>().getVidaActual();

        if (numPocionesSalud > 0 && vida < 100)
        {
            GetComponent<Combate>().curar();
            gastarPocion();
        }
        else if (numPocionesSalud == 0)
        {
            Debug.Log("No tienes pociones de salud");
        }
        else
        {
            Debug.Log("Vida llena");
        }
    }

    public void cambiarArma()
    {
        if (armaActual.Equals(0))
        {
            imagen.sprite = Resources.Load<Sprite>("armas/defaultsword");
            personaje.setAtk(50);
            movimiento.aumentarVel(6);
        }
        else if (armaActual.Equals(1))
        {
            imagen.sprite = Resources.Load<Sprite>("armas/testsword");
            personaje.setAtk(100);
            movimiento.aumentarVel(8);
        }
        else if (armaActual.Equals(2))
        {
            imagen.sprite = Resources.Load<Sprite>("armas/sword2");
            personaje.setAtk(200);
            movimiento.aumentarVel(9);
        }
        else
        {
            personaje.setAtk(0);
        }
    }

    public void aumentarPociones()
    {
        numPocionesSalud++;
        contador.text = "x" + numPocionesSalud;
    }

    public void gastarPocion()
    {
        numPocionesSalud--;
        contador.text = "x"+ numPocionesSalud.ToString();
    }

    public void desbloquearArma(int n)
    {
        if(armas[1] == 0)
        {
            armas[1] = n;
        }
        else
        {
            armas[2] = n;
        }
    }

    public void ganarCoins(int mount)
    {
        coins += mount;
        textoMonedas.text = coins.ToString();

    }

    public int getCoins()
    {
        return coins;
    }

}
