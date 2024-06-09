using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject prota1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = transform.position;
        posicion.x = prota1.transform.position.x;
        posicion.y = prota1.transform.position.y;
        transform.position = posicion;
    }
}
