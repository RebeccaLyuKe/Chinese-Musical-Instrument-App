using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using DG.Tweening;


public class SoundPlayingForDXQ : MonoBehaviour
{

    public int number;
    private Transform String;
    public int Term;
    private Vector2 multiPosition1=new Vector2();
    private Vector2 multiPosition2=new Vector2();
    Vector2 m_screenPos = new Vector2();

    private string audioPath;
    private AudioClip audioClip;
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
    public Transform rocker;
    string hitName1 = null;
    string hitName2 = null;
    bool rockerOn = false;
    bool stringOn = false;
    int rockerNum=2;
    int stringNum=2;



    void Awake()
    {
        Input.multiTouchEnabled = true;
        
        Term=0;
        String=this.GetComponent<Transform>();
        
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


            /*if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                RaycastHit hitInfo = new RaycastHit();

                if(Physics.Raycast(ray,out hitInfo))
                {
                    if(hitInfo.collider.transform.name==String.name)
                    {
                        //StringPlaying(Term, audioSources);
                        audioPath = "dxq_"+number.ToString();

                        audioClip=(AudioClip)Resources.Load(audioPath, typeof(AudioClip));
                        for(int i=0;i<10; i=i+1)
                        {
                            audioSourceTeam[i].clip=audioClip;
                            audioSourceTeam[i].clip.LoadAudioData();
                            audioSourceTeam[i].volume=1.0f;
                        }
                        Debug.Log("Term:"+Term+";ClipTerm:"+GetClipTerm(Term)+"Path:"+audioPath);
                        StringPlaying(Term, audioSourceTeam);
                        Term ++;
                    }
                }
            }*/
           


        if(Input.touchCount==1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                m_screenPos = Input.touches[0].position;

                Ray ray = Camera.main.ScreenPointToRay(m_screenPos);


                RaycastHit hitInfo = new RaycastHit();

                if(Physics.Raycast(ray,out hitInfo))
                {
                    if(hitInfo.collider.transform.name==String.name)
                    {
                        audioPath = "dxq_"+number.ToString();

                        audioClip=(AudioClip)Resources.Load(audioPath, typeof(AudioClip));
                        for(int i=0;i<10; i=i+1)
                        {
                            audioSourceTeam[i].clip=audioClip;
                            audioSourceTeam[i].clip.LoadAudioData();
                            audioSourceTeam[i].volume=1.0f;
                        }
                        StringPlaying(Term, audioSourceTeam);
                        Term ++;
                    }
                }
            } 
        }

        else if (Input.touchCount >1)
        {

            for(int i = 0; i < 2; i ++ )
            {
                Touch touch = Input.touches[i];
                //if (touch.phase == TouchPhase.Began)
                //{
                    if(i == 0)
                    {
                        multiPosition1=touch.position;
                        Ray ray = Camera.main.ScreenPointToRay(multiPosition1);

                        RaycastHit hitInfo = new RaycastHit();

                        if(Physics.Raycast(ray,out hitInfo))
                        {
                            hitName1=hitInfo.collider.transform.name;
                            if(hitName1==rocker.name)
                            {
                                rockerNum=i;
                                rockerOn=true;
                            }
                            else if (hitName1==String.name && Input.touches[i].phase == TouchPhase.Began)
                            {
                                stringNum=i;
                                stringOn=true;
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
                            hitName2=hitInfo.collider.transform.name;
                            if(hitName2==rocker.name)
                            {
                                rockerNum=i;
                                rockerOn=true;
                            }
                            else if (hitName2==String.name && Input.touches[i].phase == TouchPhase.Began)
                            {
                                stringNum=i;
                                stringOn=true;
                            }
                        }

                    }
                //}
            }
            if(rockerOn & stringOn)
            {
                audioPath = "dxq_"+number.ToString();

                audioClip=(AudioClip)Resources.Load(audioPath, typeof(AudioClip));
                for(int i=0;i<10; i=i+1)
                {
                    audioSourceTeam[i].clip=audioClip;
                    audioSourceTeam[i].clip.LoadAudioData();
                    audioSourceTeam[i].volume=1.0f;
                }
                StringPlaying(Term, audioSourceTeam);
                Term ++;
                stringOn = false;

                if(Input.touches[rockerNum].phase == TouchPhase.Ended) 
                rockerOn=false;
            }
            else
            {
                rockerOn = false;
                stringOn = false;
            }

        }
    }

    public void StringPlaying(int Term, AudioSource[] audioSourceTeam)
    {
        //audioSourceTeam[GetClipTerm(Term)].PlayScheduled(AudioSettings.dspTime);
        audioSourceTeam[GetClipTerm(Term)].Play();
        //如果弹奏同音，前一轮声音音量渐弱直至静音
        if(Term!=0)
        {
            if(audioSourceTeam[GetClipTerm(Term)].isPlaying)
            {
                //StartCoroutine(WaitAndStop(audioSources[GetClipTerm(Term-1)],0.04f));
                DOTween.To(()=> audioSourceTeam[GetClipTerm(Term)].volume, value => audioSourceTeam[GetClipTerm(Term)].volume = value, 1, 0.8f);
            }
        }
    }

    private int GetClipTerm(int Term)
    {
        Term=Term-Term/10*10;
        return Term;

    }

}
