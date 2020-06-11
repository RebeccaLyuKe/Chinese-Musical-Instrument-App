using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanelSetActive : MonoBehaviour
{

    public void ClickAndSetActive()
    {
        if(gameObject==null)
        {
            return;
        }
        if(gameObject.activeSelf==false)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
