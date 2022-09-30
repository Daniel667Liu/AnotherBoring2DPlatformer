using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatHelp : MonoBehaviour
{
    private PlayerInfo playerInfo;
    public float cheatTimeDown = 0f;
    public AudioSource audio;
    private PlayerMovement player;
    private bool cheatStart = false;
    private GameStateManager stateManager;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
        player = FindObjectOfType<PlayerMovement>();
        stateManager = FindObjectOfType<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isAlive) 
        {
            cheatTimeDown = 0f;
        }
        cheatTimeDown += 1f * Time.deltaTime;
        if (Input.anyKeyDown) 
        {
            cheatTimeDown = 0f;
        }
        if (cheatTimeDown >= 30f) 
        {
            StartCheating();
        }
        if (Input.GetKey(KeyCode.Alpha0)) 
        {
            cheatTimeDown = 31f;
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            stateManager.GameRestart();
        }
    }

    void StartCheating() 
    {
        if (!cheatStart) 
        {
            playerInfo.playerHealth = 999;
            audio.Play();
            cheatStart = true;
        }
        
    }


}
