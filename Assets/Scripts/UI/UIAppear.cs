using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{

    public RawImage EyesImage = null;

    // Start is called before the first frame update
    void Start()
    {
        EyesImage.canvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (UIManager.Instance.FadeInGo == true)
        {
            FadeIn();
            Debug.Log("FadeIN");
        }

        if (UIManager.Instance.FadeOutGo == true)
        {
            FadeOut();
            Debug.Log("FadeOUT");
        }
    }
    public void FadeIn()
    {
        EyesImage.CrossFadeAlpha(1, 2, false);
        UIManager.Instance.FadeInGo = false;
    }

    public void FadeOut()
    {
        EyesImage.CrossFadeAlpha(0, 2, false);
        UIManager.Instance.FadeOutGo = false;
    }
}
