using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameEndState : gameBaseState
{
    public override void EnterState(GameStateManager stateManager)
    {
        stateManager.player.isAlive = false;
        stateManager.gameOverAudio.Play();
        stateManager.endUI.SetActive(true);
        
    }
    public override void UpdateState(GameStateManager stateManager)
    {
        
    }

    public override void ExitState(GameStateManager stateManager)
    {
        
        
    }
}
