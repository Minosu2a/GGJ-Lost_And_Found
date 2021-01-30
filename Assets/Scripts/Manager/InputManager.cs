using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    #region Fields
    private Vector3 _moveDir = Vector3.zero;

    #endregion Fields

    #region Properties
    public Vector3 MoveDir => _moveDir;
    #endregion Properties

    #region Events
    private event Action _onInteractionPressed = null;
    public event Action OnInteractionKeyPressed
    {
        add
        {
            _onInteractionPressed -= value;
            _onInteractionPressed += value;
        }
        remove
        {
            _onInteractionPressed -= value;
        }
    }

    #endregion Events

    #region Methods
    public void Initialize()
    {

    }


    protected override void Update()
    {

        if(Input.GetButtonDown("Fire3"))
        {
            if (_onInteractionPressed != null)
            {
                _onInteractionPressed();
            }
        }

        _moveDir.x = Input.GetAxis("Horizontal");
        _moveDir.z = Input.GetAxis("Vertical");
    }

    #endregion Methods



}
