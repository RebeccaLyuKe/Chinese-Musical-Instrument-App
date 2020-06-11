using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIt : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public void ClickAndShow()
    {
            canvasGroup = gameObject.GetComponent<CanvasGroup>();           
            canvasGroup.alpha=1;  
    }

    public void Hide()
    {
            canvasGroup = gameObject.GetComponent<CanvasGroup>();           
            canvasGroup.alpha=0;  
    }
}
