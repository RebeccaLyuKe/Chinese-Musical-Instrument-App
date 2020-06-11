using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using DG.Tweening;

public class StopSound : MonoBehaviour
{
    public AudioSource[] audioSourceTeam;
 
    public AudioSource audioSourceTeam1;
    public AudioSource audioSourceTeam2;
    public AudioSource audioSourceTeam3;
    public AudioSource audioSourceTeam4;
    public AudioSource audioSourceTeam5;
    public AudioSource audioSourceTeam6;
    public AudioSource audioSourceTeam7;
    public AudioSource audioSourceTeam8;
    public AudioSource audioSourceTeam9;
    public AudioSource audioSourceTeam10;
    private Transform stringTransform;
    private Vector2 multiPosition1=new Vector2();
    private Vector2 multiPosition2=new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        stringTransform = this.GetComponent<Transform>();
        audioSourceTeam = new AudioSource[]
        {
            audioSourceTeam1,
            audioSourceTeam2,
            audioSourceTeam3,
            audioSourceTeam4,
            audioSourceTeam5,
            audioSourceTeam6,
            audioSourceTeam7,
            audioSourceTeam8,
            audioSourceTeam9,
            audioSourceTeam10
        };
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.touchCount <= 0)
        //return;
        if (EventSystem.current.IsPointerOverGameObject()||EventSystem.current.currentSelectedGameObject != null)
        return;

        if(Input.touchCount==1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            //if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo = new RaycastHit();
                if(Physics.Raycast(ray,out hitInfo))
                {
                    if(hitInfo.collider.transform.name==stringTransform.name)
                    {
                        for(int i=0; i<10; i++)
                        {
                                audioSourceTeam[i].volume = Mathf.Lerp(audioSourceTeam[i].volume, 0f, Time.deltaTime * 60.0f);                            
                        }
                    }
                }
            } 
        }

        if(Input.touchCount==2)
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
                            if(hitInfo.collider.transform.name==stringTransform.name)
                            {
                                for(int j=0; j<10; j++)
                                {
                                        audioSourceTeam[j].volume = Mathf.Lerp(audioSourceTeam[j].volume, 0f, Time.deltaTime * 60.0f);                            
                                }
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
                            if(hitInfo.collider.transform.name==stringTransform.name)
                            {
                                for(int j=0; j<10; j++)
                                {
                                        audioSourceTeam[j].volume = Mathf.Lerp(audioSourceTeam[j].volume, 0f, Time.deltaTime * 60.0f);                            
                                }
                            }
                        }

                    }
                }
            }
        }
        
    }
}
