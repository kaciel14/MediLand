using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMode : MonoBehaviour
{
    private SkeletonSpawn esqueleto;
    private GhostSpawn ghost;
    private SlimeSpawn slime;

    // Start is called before the first frame update
    void Start()
    {
        esqueleto = GetComponent<SkeletonSpawn>();
        ghost = GetComponent<GhostSpawn>();
        slime = GetComponent<SlimeSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hardMode()
    {
        esqueleto.aumentarDificultad();
        ghost.aumentarDificultad();
        slime.aumentarDificultad();
    }
}
