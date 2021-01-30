using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Fields
    [SerializeField] Transform _soundPos = null;
    #endregion Fields
    #region Property
    #endregion Property


    #region Methods
    private void Awake()
    {
        UIManager.Instance.UIController = this;    
    }

    public void TooglePause()
    {
        GameManager.Instance.TogglePause();
    }

    public void SoundTest()
    {
        AudioManager.Instance.Play3DSound("snd_test", _soundPos);
    }

    #endregion Methods


}
