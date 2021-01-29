using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ACharacterState
{
    #region Fields
    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methods
    public override void EnterState()
    {
        Debug.Log("Enter Idle State");
    }

    public override void UpdateState()
    {
        if(InputManager.Instance.MoveDir != Vector3.zero)
        {
            _controller.ChangeState(ECharacterState.WALK);
        }
    }

    public override void ExitState()
    {
        Debug.Log("Exit Idle State");
    }

    #endregion Methods

}
