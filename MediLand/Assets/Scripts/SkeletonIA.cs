using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkeletonIA : MonoBehaviour
{
    private GameObject casa;
    int distanciaX, distanciaY, protaDisX, protaDisY;
    Rigidbody2D cuerpo;
    GameObject prota;
    

    // Start is called before the first frame update
    void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
        prota = GameObject.Find("prota1");
        casa = GameObject.Find("casa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        distanciaX = (int)Math.Abs(transform.position.x - casa.transform.position.x);
        distanciaY = (int)Math.Abs(transform.position.y - casa.transform.position.y);

        float posx = transform.position.x - casa.transform.position.x;
        float posy = transform.position.y - casa.transform.position.y;

        protaDisX = (int)Math.Abs(transform.position.x - prota.transform.position.x);
        protaDisY = (int)Math.Abs(transform.position.y - prota.transform.position.y);

        float posxProta = transform.position.x - prota.transform.position.x;
        float posyProta = transform.position.y - prota.transform.position.y;

        bool seguirProta;

        if (protaDisX < distanciaX || protaDisY < distanciaY)
        {
            seguirProta = true;
        }
        else
        {
            seguirProta = false;
        }

        if (!seguirProta)
        {
            if (distanciaX > 0 || distanciaY > 0)
            {

                if (distanciaX > distanciaY)
                {
                    if (posx > 0) cuerpo.velocity = new Vector2(-3, 0);
                    else cuerpo.velocity = new Vector2(3, 0);
                }
                else
                {
                    if (posy > 0) cuerpo.velocity = new Vector2(0, -3);
                    else cuerpo.velocity = new Vector2(0, 3);
                }
            }
            else
            {
                cuerpo.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            if (protaDisX > 0 || protaDisY > 0)
            {

                if (protaDisX > protaDisY)
                {
                    if (posxProta > 0) cuerpo.velocity = new Vector2(-3, 0);
                    else cuerpo.velocity = new Vector2(3, 0);
                }
                else
                {
                    if (posyProta > 0) cuerpo.velocity = new Vector2(0, -3);
                    else cuerpo.velocity = new Vector2(0, 3);
                }
            }
            else
            {
                cuerpo.velocity = new Vector2(0, 0);
            }
        }

        //transform.position = posc;

    }
}

