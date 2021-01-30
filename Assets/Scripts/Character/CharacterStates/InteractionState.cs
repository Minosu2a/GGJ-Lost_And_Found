using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionState : ACharacterState
{
    #region Fields
    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methods
    public override void EnterState()
    {
        Debug.Log("Enter Interaction State");
    }

    public override void UpdateState()
    {
        if (InputManager.Instance.Interaction == true)
        {
            _controller.ChangeState(ECharacterState.INTERACTION);
        }
    }

    public override void ExitState()
    {
        Debug.Log("Exit Interaction State");
    }

    #endregion Methods
}
