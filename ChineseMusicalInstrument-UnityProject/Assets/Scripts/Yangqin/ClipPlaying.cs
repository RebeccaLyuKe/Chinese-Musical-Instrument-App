using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using DG.Tweening;


public class ClipPlaying : MonoBehaviour
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
    /*
    private AudioSource audioSourceTeam1;
    private AudioSource audioSourceTeam2;
    private AudioSource audioSourceTeam3;
    private AudioSource audioSourceTeam4;
    private AudioSource audioSourceTeam5;
    private AudioSource audioSourceTeam6;
    private AudioSource audioSourceTeam7;
    private AudioSource audioSourceTeam8;
    private AudioSource audioSourceTeam9;
    private AudioSource audioSourceTeam10;
    */


    void Awake()
    {
        Input.multiTouchEnabled = true;
        
        Term=0;
        String=this.GetComponent<Transform>();
        audioPath = number.ToString();
        AudioSource audioSourceTeam1 = gameObject.AddComponent<AudioSource>();
        AudioSource audioSourceTeam2 = gameObject.AddComponent<AudioSource>();
        AudioSource audioSourceTeam3 = gameObject.AddComponent<AudioSource>();
        AudioSource audioSourceTeam4 = gameObject.AddComponent<AudioSource>();
        AudioSource audioSourceTeam5 = gameObject.AddComponent<AudioSource>();
        AudioSource audioSourceTeam6 = gameObject.AddComponent<AudioSource>();
        AudioSource audioSourceTeam7 = gameObject.AddComponent<AudioSource>();
        AudioSource audioSourceTeam8 = gameObject.AddComponent<AudioSource>();
        AudioSource audioSourceTeam9 = gameObject.AddComponent<AudioSource>();
        AudioSource audioSourceTeam10 = gameObject.AddComponent<AudioSource>();

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
        audioClip=(AudioClip)Resources.Load(audioPath, typeof(AudioClip));
        for(int i=0;i<10; i=i+1)
        {
            audioSourceTeam[i].clip=audioClip;
            audioSourceTeam[i].clip.LoadAudioData();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.touchCount <= 0)
            //return;

            if (EventSystem.current.IsPointerOverGameObject()||EventSystem.current.currentSelectedGameObject != null)
            return;


            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                RaycastHit hitInfo = new RaycastHit();

                if(Physics.Raycast(ray,out hitInfo))
                {
                    if(hitInfo.collider.transform.name==String.name)
                    {
                        //StringPlaying(Term, audioSources);
                        Debug.Log("Term:"+Term+";ClipTerm:"+GetClipTerm(Term)+"Path:"+audioPath);
                        StringPlaying(Term, audioSourceTeam);
                        Term ++;
                    }
                }
            } 
           


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
                        StringPlaying(Term, audioSourceTeam);
                        Term ++;
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
                            if(hitInfo.collider.transform.name==String.name)
                            {
                                StringPlaying(Term, audioSourceTeam);
                                Term ++;
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
                            if(hitInfo.collider.transform.name==String.name)
                            {
                                StringPlaying(Term, audioSourceTeam);
                                Term ++;
                            }
                        }

                    }
                }
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
                DOTween.To(()=> audioSourceTeam[GetClipTerm(Term)].volume, value => audioSourceTeam[GetClipTerm(Term)].volume = value, 1, 0.5f);
            }
        }
    }


    IEnumerator WaitAndStop(AudioSource audioSource, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        audioSource.Stop();
    }

    private int GetClipTerm(int Term)
    {
        Term=Term-Term/10*10;
        return Term;

    }

}
