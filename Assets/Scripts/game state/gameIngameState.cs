using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameIngameState : gameBaseState
{
   
    public override void EnterState(GameStateManager stateManager)
    {
        stateManager.player.isAlive = true;
    }
    public override void UpdateState(GameStateManager stateManager)
    {
        if (stateManager.playerInfo.playerHealth <= 0) 
        {
            stateManager.GameFinish();
        }
    }

    public override void ExitState(GameStateManager stateManager)
    {
       
    }
}
