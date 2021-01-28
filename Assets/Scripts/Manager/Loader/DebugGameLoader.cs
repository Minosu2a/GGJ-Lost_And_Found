using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameLoader : MonoBehaviour
{


    #region Fields
    [SerializeField] private GameManager _gameManager = null;
    [SerializeField] private InputManager _inputManager = null;
    [SerializeField] private UIManager _uiManager = null;
    [SerializeField] private AudioManager _audioManager = null;
    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methods

    private void Start()
    {
        _gameManager.Initialize();
        _inputManager.Initialize();
        _uiManager.Initialize();
        _audioManager.Initialize();
    }

    #endregion Methods



}
