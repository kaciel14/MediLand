using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveControl : MonoBehaviour
{
    public int wave = 0;
    public int derrotados = 0;
    bool descanso = false;

    private float descansoInicio;
    private float descansoFin = 0;

    public Text info;

    public GameObject musica;
    private GameObject casa;

    //public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        casa = GameObject.Find("casa");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(descansoFin);
      if (derrotados >= (wave * 30))
      {
         if (descanso)
         {
             avanzaWave();
         }
         else
         {
            finalizarWave();
            avanzaWave();
         }
      }
    
    }

    public void avanzaWave()
    {

        if (descanso)
        {
            if (Time.realtimeSinceStartup > descansoFin)
            {
                descanso = false;
                wave++;
                avanzaWave();
                derrotados = 0;
            }

            casa.GetComponent<CasaControl>().resetCasa();
        }
        else
        {
            if(wave == 1)
            {
                Debug.Log("Inicio wave 1");
                info.text = "Wave 1";
                FindInActiveObjectByName("spawn").SetActive(true);
                musica.GetComponent<MusicControl>().resetMusica();
            }
            else
            {
                Debug.Log("Inicio wave "+wave);
                info.text = "Wave " + wave;

                casa.GetComponent<CasaControl>().resetCasa();
                musica.GetComponent<MusicControl>().resetMusica();

                if(wave >= 5)
                {
                    for (int i = 4; i > 1; i--)
                    {
                        FindInActiveObjectByName("spawn" + (i - 1) + "").SetActive(true);
                    }
                    FindInActiveObjectByName("spawn").SetActive(true);

                    masDificultad();
                }
                else
                {
                    for (int i = wave; i > 1; i--)
                    {
                        FindInActiveObjectByName("spawn" + (i - 1) + "").SetActive(true);
                    }
                    FindInActiveObjectByName("spawn").SetActive(true);
                }

                
            }
           
        }
    }

    public void finalizarWave()
    {
        descanso = true;
        descansoInicio = Time.realtimeSinceStartup;
        descansoFin = descansoInicio + 14.0f;
        peace();

        musica.GetComponent<MusicControl>().apagarMusica();
        
        if(wave == 0)
        {
            info.text = "Bienvenido, comenzando...";
        }
        else
        {
            info.text = "Wave finalizada, preparate...";
        }

        Debug.Log("Wave Finalizada, tiempo de descanso");
        if (wave == 1)
        {
            FindInActiveObjectByName("spawn").SetActive(false);
        }
        else if(wave >=5)
        {
            for (int i = 4; i > 1; i--)
            {
                FindInActiveObjectByName("spawn" + (i - 1) + "").SetActive(false);
            }
            FindInActiveObjectByName("spawn").SetActive(false);
        }
        else
        {
            for(int i= wave; i>1; i--)
            {
                FindInActiveObjectByName("spawn" + (i - 1) + "").SetActive(false);
            }
            FindInActiveObjectByName("spawn").SetActive(false);

        }
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    public void masDificultad()
    {
        GameObject s;
        for (int i = 4; i > 1; i--)
        {
            s= FindInActiveObjectByName("spawn" + (i - 1) + "");
            s.GetComponent<HardMode>().hardMode();
        }
        s=FindInActiveObjectByName("spawn");
        s.GetComponent<HardMode>().hardMode();
    }

    public void peace()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach(GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
    }




}
