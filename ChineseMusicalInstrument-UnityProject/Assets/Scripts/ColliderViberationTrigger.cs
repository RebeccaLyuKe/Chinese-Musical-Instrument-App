using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColliderViberationTrigger : MonoBehaviour
{
    public Transform stringTransform;
    private Transform colliderTransform;
    private Vector2 multiPosition1=new Vector2();
    private Vector2 multiPosition2=new Vector2();
    Vector2 m_screenPos = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        Input.multiTouchEnabled = true;        
        colliderTransform = this.GetComponent<Transform>();

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount <= 0)
        return;

        if(Input.touchCount==1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                m_screenPos = Input.touches[0].position;

                Ray ray = Camera.main.ScreenPointToRay(m_screenPos);


                RaycastHit hitInfo = new RaycastHit();

                if(Physics.Raycast(ray,out hitInfo))
                {
                    if(hitInfo.collider.transform.name==colliderTransform.name)
                    {
                        MyShake(stringTransform);
                    }
                }
            } 
        }

        else if (Input.touchCount >1)
        {

            for(int i=0; i<2;i++)
            {
                Touch touch = Input.touches[i];
                if (touch.phase == TouchPhase.Began)
                {
                    if(i==0)
                    {
                        multiPosition1=touch.position;
                        Ray ray = Camera.main.ScreenPointToRay(multiPosition1);

                        RaycastHit hitInfo = new RaycastHit();

                        if(Physics.Raycast(ray,out hitInfo))
                        {
                            if(hitInfo.collider.transform.name==colliderTransform.name)
                            {
                                MyShake(stringTransform);
                            }
                        }
                    }
                    else
                    {
                        multiPosition2=touch.position;
                        Ray ray = Camera.main.ScreenPointToRay(multiPosition2);

                        RaycastHit hitInfo = new RaycastHit();

                        if(Physics.Raycast(ray,out hitInfo))
                        {
                            if(hitInfo.collider.transform.name==colliderTransform.name)
                            {
                                MyShake(stringTransform);
                            }
                        }

                    }
                }
            }

        }
    }

    public void MyShake(Transform tf)
    {
        if(tf!=null)
        {
            Tweener tweener = tf.DOShakePosition(1,new Vector3(0,0.0007f,0),15);
        }
    }
}