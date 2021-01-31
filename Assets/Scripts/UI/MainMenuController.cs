using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    
    #region Fields
    [SerializeField] private GameObject _menuMain = null;
    [SerializeField] private GameObject _menuCredits = null;
    [SerializeField] private GameObject _echo = null;
    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methods
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Echo");
         //   GameObject Echoclone = Instantiate(_echo, , Quaternion.identity);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 15.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            GameObject Echoclone = Instantiate(_echo, objectPos, Quaternion.identity);
            //  if (Physics.Raycast(ray))

        }
    }

    public void Play()
    {
        GameStateManager.Instance.LaunchTransition(EGameState.GAME);
    }


    public void Credits()
    {
        _menuMain.SetActive(false);
        _menuCredits.SetActive(true);

    }

    public void ReturnCredits()
    {
        _menuMain.SetActive(true);
        _menuCredits.SetActive(false);

    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion Methods



}
