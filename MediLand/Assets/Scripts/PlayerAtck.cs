using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAtck : MonoBehaviour
{

    public Transform jugador;

    public LayerMask mascara;

    private Animator animator;

    private int dmg = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("ataque");
            animator.SetBool("caminar",false);
            try
            {
                atack();
            }
            catch (NullReferenceException e)
            {

            }
            
            
        }
    }

    private void atack()
    {
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(jugador.position, 2, mascara);

        foreach (Collider2D enemigo in enemigos)
        {
            enemigo.GetComponent<EnemyControl>().recibeDmg(dmg);
            Debug.Log("Daño");
        }
    }

    public void setAtk(int value)
    {
        dmg = value;
    }
}
