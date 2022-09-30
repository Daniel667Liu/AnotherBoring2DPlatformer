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
    public bool isAlive = false;
    Animator animator;
    public AudioSource jumpAudio;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateRigidbody();
        if (isAlive) 
        {
            MoveLeft();
            MoveRight();
            updateSpriteDirection();
            Jump();
            CheckIfGrounded();
        }
        
        
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
                jumpAudio.Play();
            }
        }
        
       
    }

    void CheckIfGrounded()
    {
        RaycastHit2D hitted2D = Physics2D.Raycast(GetComponent<Transform>().position, new Vector2(0f, -1f), 1.5f);
        if (hitted2D)
        {
            isInAir = false;
        }
        else
        {
            isInAir = true;
        }


    }

    void UpdateRigidbody() 
    {
        if (isAlive)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1f;

        }
        else 
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;

        }
    }
}
