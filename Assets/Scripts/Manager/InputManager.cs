using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    #region Fields
    private Vector3 _moveDir = Vector3.zero;
    private bool _interaction = false;
    private float _gravityForce = -0.5f;
    #endregion Fields

    #region Properties
    public Vector3 MoveDir
    {
        get
        {
            return _moveDir;
        }
        set
        {
            _moveDir = value;
        }
    }

    public bool Interaction
    {
        get
        {
            return _interaction;
        }
    }
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
                _interaction = true;
            }
        }

        if (Input.GetButtonUp("Fire3"))
        {
            if (_onInteractionPressed != null)
            {
                _interaction = false;
            }
        }

        _moveDir.x = Input.GetAxis("Horizontal");
        _moveDir.z = Input.GetAxis("Vertical");
        _moveDir.y = _gravityForce;
    }

    #endregion Methods



}
