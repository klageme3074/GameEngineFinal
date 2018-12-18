using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDLE : FSMState
{
    private void Awake()
    {
        
    }

    public override void BeginState()
    {
        base.BeginState();
        if (_manager == null)
        {
            _manager = GetComponent<FSMManager>();
        }
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _manager.SetState(PlayerState.MOVE);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _manager.SetState(PlayerState.PUNCH);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _manager.SetState(PlayerState.KICK);
        }
    }
    
}