using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    
    

    //get the reference of every game states
    gameBaseState currentState;
    gameStartState gameStartState = new gameStartState();
    gameIngameState gameIngameState = new gameIngameState();
    gameEndState gameEndState = new gameEndState();



    public PlayerInfo playerInfo;
    public GameObject startUI;
    public GameObject endUI;
    public AudioSource gameOverAudio;
    public PlayerMovement player;
    
    
    
    void Start()
    {
        //change current state for test
        currentState = gameStartState;
        currentState.EnterState(this);
        
        playerInfo = FindObjectOfType<PlayerInfo>();
        player = FindObjectOfType<PlayerMovement>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        currentState.UpdateState(this);
    }

    public void transitState( gameBaseState next) //used for transit into next game state
    {
        currentState.ExitState(this);
        next.EnterState(this);
        currentState = next;
    }

    public void GameStart() 
    {
        
        transitState(gameIngameState);
    }

    public void GameFinish() 
    {
        transitState(gameEndState);
        
    }

    public void GameRestart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
    

    
}
