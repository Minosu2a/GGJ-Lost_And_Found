﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : ACharacterState
{
    #region Fields
    private float _echoDelay = 0.7f;

    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methods
    public override void EnterState()
    {
        TimerEcho.OnTick += _controller.Echo;
        TimerEcho.StartTimer(_echoDelay);



        Debug.Log("Enter Walk State");
    }

    public override void UpdateState()
    {
        _controller.Walk();
        
        if (InputManager.Instance.MoveDir == Vector3.zero)
        {
            _controller.ChangeState(ECharacterState.IDLE);
        }
    }

    public override void ExitState()
    {
        TimerEcho.OnTick -= _controller.Echo;
        Debug.Log("Exit Walk State");
    }

    
    #endregion Methods
}