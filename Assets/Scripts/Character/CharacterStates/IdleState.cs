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
        if(InputManager.Instance.MoveDir.x != 0f || InputManager.Instance.MoveDir.z != 0f)
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
