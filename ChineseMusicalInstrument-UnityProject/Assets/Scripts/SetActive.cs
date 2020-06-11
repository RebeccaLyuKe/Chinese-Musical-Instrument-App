using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public GameObject other1;
    public GameObject other2;
    public void ClickAndSetActive()
    {
            canvasGroup = gameObject.GetComponent<CanvasGroup>();
            other1.GetComponent<CanvasGroup>().alpha=0;
            other2.GetComponent<CanvasGroup>().alpha=0;            

            if(canvasGroup.alpha==0) 
            {
                canvasGroup.alpha=1;  
                Debug.Log("显示");  
            }
            else
            { 
                canvasGroup.alpha=0;  
                Debug.Log("隐藏");       
            }

    }

}
