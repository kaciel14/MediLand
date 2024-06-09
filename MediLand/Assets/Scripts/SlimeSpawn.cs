using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawn : MonoBehaviour
{
    public GameObject enemigo;
    public float siguiente;
    float actual = 0.0f;

    public float px, py;
    public float dx, dy;

    // Start is called before the first frame update
    void Start()
    {
        px = GetComponent<Transform>().position.x;
        py = GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (actual != siguiente)
        {
            actual += 1;
        }
        else
        {
            actual = 0;
            float randx = Random.Range(px - dx, px + 18);
            float randy = Random.Range(py - dy, py + 14);
            Instantiate(enemigo, new Vector3(randx, randy, -6), Quaternion.identity);
        }
    }

    public void aumentarDificultad()
    {
        siguiente = siguiente * 0.8f;
    }
}
