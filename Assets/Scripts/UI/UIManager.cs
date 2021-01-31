using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    #region Fields
    private UIController _uiController = null;
    private bool _fadeIn = false;
    private bool _fadeOut = false;
    #endregion Fields


    #region Property
    public UIController UIController
    {

        get
        {
            return _uiController;
        }
        set
        {
            if (_uiController == null)
            {
                _uiController = value;
            }
        }

    }

    public bool FadeInGo
    {
        get
        {
            return _fadeIn;
        }
        set
        {
            _fadeIn = value;
        }
    }

    public bool FadeOutGo
    {
        get
        {
            return _fadeOut;
        }
        set
        {
            _fadeOut = value;
        }
    }
    #endregion Property


    #region Methods

    public void Initialize()
    {
        base.Start();
    }
    #endregion Methods


}
