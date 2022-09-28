using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        animator.SetBool("inAir", movement.isInAir);
        
        Debug.DrawRay(GetComponent<Transform>().position, new Vector3(0, -1, 0), Color.red,1f, false);
        
    }


    
}
