using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PitchController : MonoBehaviour
{
    private Transform rocker;
    public Transform stringTF;
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
    private float startingPitch=1.0f;

    private Quaternion q;
    private Vector3 mousePos;
    private Vector3 preMousePos;
    private Vector3 modelPos;
    private Vector3 localEuler;
    private Vector3 emptyEuler;
    private Vector3 oStringScale;
    private Vector3 scaleChange;
    private float RotateAngle;
    private bool IsSelect = false;
    private float angle; 
    public Camera ca;
    private int rockerFingerNum;
    private float h;
    private float stringLength;
    private float x;
    public Transform startP1;
    public Transform startP2;
    private float L1;


    // Start is called before the first frame update
    void Start()
    {
        rocker=this.GetComponent<Transform>();

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
        for(int i =0;i<10;i++)
        {
            audioSourceTeam[i].pitch=startingPitch;
        }
        modelPos=ca.WorldToScreenPoint(rocker.transform.position);
        angle = localEuler.z;
        rocker.transform.localEulerAngles=localEuler;
        emptyEuler=new Vector3(0f,0f,0f);
        oStringScale=stringTF.transform.localScale;

        h=startP1.transform.position.y-startP2.transform.position.y;
        stringLength=stringTF.transform.position.x-startP2.transform.position.x;
        L1=stringLength*0.04f;


        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.touchCount <= 0)
            //return;
        
        if(Input.touchCount==1||Input.touchCount==2)
        {
            for (int i=0; i<Input.touchCount; i ++)
            {
                if (Input.touches[i].phase == TouchPhase.Began)
                {
                    
                    Ray ray = Camera.main.ScreenPointToRay(Input.touches[i].position);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        if(hitInfo.collider.transform.name==rocker.name)
                        {
                            IsSelect=true;
                            preMousePos=mousePos=Input.mousePosition;
                            rockerFingerNum = i;
                        }
                    }
                }
            }

            if(Input.touches[rockerFingerNum].phase == TouchPhase.Moved && IsSelect)
            {
                IsSelect = true;
                mousePos = Input.touches[rockerFingerNum].position;
                //获得旋转角度
                RotateAngle=Vector3.Angle(preMousePos-modelPos, mousePos-modelPos);

                if (RotateAngle == 0)
                {
                    preMousePos=mousePos;
                }
                else
                {
                    q=Quaternion.FromToRotation(preMousePos-modelPos, mousePos-modelPos);
                    float k = q.z >0 ?1:-1;
                    localEuler.z +=k*RotateAngle;
                    angle=localEuler.z=Mathf.Clamp(localEuler.z,-36000,36000);

                    //设定边界
                    if(angle<=33.7f && angle>=-21.5f)
                    rocker.transform.localEulerAngles=localEuler;
                    else if(angle>33.7f) 
                        angle=33.7f;
                    else
                        angle=-21.5f;

                    x=h*Convert.ToSingle(Mathf.Tan(angle*Convert.ToSingle(Mathf.Deg2Rad)));
                    scaleChange=new Vector3((stringLength+x)/stringLength-1f,0f,0f);
                    stringTF.transform.localScale =oStringScale+ scaleChange;
                    Debug.Log("localEuler.x: "+localEuler.x+"; Rotate Angle: " + RotateAngle+"; angle: " + angle+"; x:"+x+"; scale:"+(stringLength+x)/stringLength);

                    for(int i=0;i<10;i++)
                    {
                        audioSourceTeam[i].pitch = startingPitch *(Convert.ToSingle(Mathf.Sqrt(1.0f+x/L1)))*(1.0f+x/(stringLength+L1));
                    }
                    preMousePos = mousePos;
                }           
            }
            
            if (Input.touches[rockerFingerNum].phase == TouchPhase.Ended)
            {
                IsSelect=false;
                rocker.transform.localEulerAngles=emptyEuler;
                localEuler=emptyEuler;
                RotateAngle=0f;
                angle=0f;
                x=0f;
                stringTF.transform.localScale = oStringScale;
                
                for(int i=0;i<10;i++)
                {
                    audioSourceTeam[i].pitch =startingPitch;
                }
            }
        }



        
        /*if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            RaycastHit hitInfo = new RaycastHit();

            if(Physics.Raycast(ray,out hitInfo))
            {
                if(hitInfo.collider.transform.name==rocker.name)
                {
                    IsSelect=true;
                    preMousePos = mousePos = Input.mousePosition;
                }
            }
        }
        if (Input.GetMouseButton (0) && IsSelect)
        {
            IsSelect = true;
            mousePos = Input.mousePosition;
            //获得旋转角度
            RotateAngle=Vector3.Angle(preMousePos-modelPos, mousePos-modelPos);

            if(RotateAngle==0)
            {
                preMousePos=mousePos;
            }
            else
            {
                q=Quaternion.FromToRotation(preMousePos-modelPos, mousePos-modelPos);
                float k = q.z >0 ?1:-1;
                localEuler.z +=k*RotateAngle;
                angle=localEuler.z=Mathf.Clamp(localEuler.z,-36000,36000);

                //设定边界
                if(angle<=33.7f && angle>=-21.5f)
                rocker.transform.localEulerAngles=localEuler;
                else if(angle>33.7f) 
                    angle=33.7f;
                else
                    angle=-21.5f;

                x=h*Convert.ToSingle(Mathf.Tan(angle*Convert.ToSingle(Mathf.Deg2Rad)));
                scaleChange=new Vector3((stringLength+x)/stringLength-1f,0f,0f);
                stringTF.transform.localScale =oStringScale+ scaleChange;
                Debug.Log("localEuler.x: "+localEuler.x+"; Rotate Angle: " + RotateAngle+"; angle: " + angle+"; x:"+x+"; scale:"+(stringLength+x)/stringLength);

                for(int i=0;i<10;i++)
                {
                    audioSourceTeam[i].pitch = startingPitch *(Convert.ToSingle(Mathf.Sqrt(1.0f+x/L1)))*(1.0f+x/(stringLength+L1));
                }
                preMousePos = mousePos;
            }
        }
        
        if(!Input.GetMouseButton(0))
        {
            IsSelect=false;
            rocker.transform.localEulerAngles=emptyEuler;
            localEuler=emptyEuler;
            RotateAngle=0f;
            angle=0f;
            x=0f;
            stringTF.transform.localScale = oStringScale;
            
            for(int i=0;i<10;i++)
            {
                audioSourceTeam[i].pitch =startingPitch;
            }

        }*/
        

  
        
    }
}
