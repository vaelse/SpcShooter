using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;
    public float speed = 0.3f;
   

    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 1f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            imageComp.fillAmount = imageComp.fillAmount - speed ;
        }
        else if (imageComp.fillAmount == 0f)
        {
            imageComp.fillAmount = 1f;
        }
    }

}
