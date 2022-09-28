using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedLimit= 1f;
    public float acceleration = 1f;
    private bool isFaceRight = true;
    [SerializeField]
    private float force = 0f;
    public float forcelimit = 5f;
    [HideInInspector]
    public bool isInAir = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        MoveRight();
        updateSpriteDirection();
        Jump();
        CheckIfGrounded();
        //Debug.Log(GetComponent<Rigidbody2D>().velocity.x);
    }

    void MoveLeft() 
    {

        if (Input.GetKey(KeyCode.A))
            {
                isFaceRight = false;
                if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x >= -1f * speedLimit)
                {
                    if (isInAir)
                    {
                        this.gameObject.GetComponent<Rigidbody2D>().velocity -= new Vector2(acceleration * Time.deltaTime * 0.5f, 0);
                    }
                    else 
                    {
                        this.gameObject.GetComponent<Rigidbody2D>().velocity -= new Vector2(acceleration * Time.deltaTime, 0);
                    }
                    
                }

            }
      
        
        
    }

    void MoveRight() 
    {

        if (Input.GetKey(KeyCode.D))
            {
                isFaceRight = true;
                if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x <= 1f * speedLimit)
                {
                    if (isInAir)
                    {
                        this.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(acceleration * Time.deltaTime * 0.5f, 0);
                    }
                    else 
                    {
                        this.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(acceleration * Time.deltaTime, 0);
                    }
                    
                }
            }
    }



    void updateSpriteDirection()
    {
        GetComponent<SpriteRenderer>().flipX = !isFaceRight;
    }

    void Jump() 
    {
        if (!isInAir) 
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (force <= forcelimit)
                {
                    force += acceleration * Time.deltaTime * 50f;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, force), ForceMode2D.Force);
                force = 0f;
                animator.SetTrigger("jump");
                isInAir = true;
            }
        }
        
       
    }

    void CheckIfGrounded()
    {
        RaycastHit2D hitted2D = Physics2D.Raycast(GetComponent<Transform>().position, new Vector2(0f, -10f), 1f);
        if (hitted2D)
        {
            isInAir = false;
        }
        else
        {
            isInAir = true;
        }


    }
}
