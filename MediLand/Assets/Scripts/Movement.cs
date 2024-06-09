using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D cuerpo;
    float h,v;

    public int vel = 6;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (h != 0 || v != 0)
        {
            animator.SetBool("caminar", true);
        }
        else
        {
            animator.SetBool("caminar", false);
        }
        cuerpo.velocity = new Vector2(h*vel, v*vel);   
    }

    public void aumentarVel(int n)
    {
        vel = n;
    }

}
    