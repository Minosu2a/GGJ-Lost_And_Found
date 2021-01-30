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
         _controller.Interaction();
         
    }

    public override void ExitState()
    {
        _controller.AnimationInteractionFinished = false;
        Debug.Log("Exit Interaction State");
    }

    #endregion Methods
}
