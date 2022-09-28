using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveRight();
    }

    public void MoveRight() 
    {
        Vector3 movement = new Vector3(speed*Time.fixedDeltaTime, 0, 0);
        GetComponent<Transform>().Translate(movement, Space.World);
    }
}
