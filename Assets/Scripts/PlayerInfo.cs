using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInfo : MonoBehaviour
{
    public int playerHealth = 3;
    public string[] damageTags;
    public GameObject winUi;
    private PlayerMovement player;
    public AudioSource bounceSound;
    public AudioSource winSound;
    public AudioSource music;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerHealth);
    }

    bool CheckDamage(GameObject otherObject) 
    {
        bool result;
        result = damageTags.Contains<string>(otherObject.tag);
        return result;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.gameObject.GetComponent<Transform>().name);
        if (CheckDamage(collision.collider.gameObject)) 
        {
            playerHealth -=1;
        }
        if (collision.collider.gameObject.CompareTag("Win")) 
        {
            winUi.SetActive(true);
            player.isAlive = false;
            music.volume *= 0.25f;
            winSound.Play();
        }
        if (collision.collider.gameObject.CompareTag("Bounce")) 
        {
            bounceSound.Play();
        }
        
    }
}
