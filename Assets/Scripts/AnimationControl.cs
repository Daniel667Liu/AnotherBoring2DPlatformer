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
    }


    void ExecuteRaycast() 
    {
        RaycastHit2D hitted2D = Physics2D.Raycast(GetComponent<Transform>().position, new Vector2(0f, -1f),1f);
    }
}
