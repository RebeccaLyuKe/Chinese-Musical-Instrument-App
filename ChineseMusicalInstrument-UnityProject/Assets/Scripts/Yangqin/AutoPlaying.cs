using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
using DG.Tweening;

public class AutoPlaying : MonoBehaviour
{
    private bool ActivateMode;
    private int beat;
    private int MoveTerm;
    public float beatDuration=0.2f;
    private string[] noteUpside;
    private string[] noteDownside;
    private GameObject aimedStringUpside;
    private GameObject aimedStringDownside;
    private GameObject aimedStringObjectUpside;
    private GameObject aimedStringObjectDownside;
    //private Highlighter highlighterStringUpside;
    //private Highlighter highlighterStringDownside;
    public GameObject Note1;
    public GameObject Note2;
    public GameObject Note3;
    public GameObject Note4;
    public GameObject Note5;
    public GameObject Note6;
    public GameObject Note7;
    public GameObject Note8;
    private float tfSpeed;
    private Vector3 beatStep;
    private Vector3 beatStepIncreasingFor4;
    private Vector3 beatStepIncreasingFor8;
    private Vector3 CurrentPos;
    public ClipPlaying clipPlaying1=null;
    public ClipPlaying clipPlaying2=null;
    public int TermInClipPlaying1;
    public int TermInClipPlaying2;
    AudioSource[] audioSourceTeamInClipPlaying1;
    AudioSource[] audioSourceTeamInClipPlaying2;




    // Start is called before the first frame update
    void Start()
    {
        beat=0;
        MoveTerm=0;
        ActivateMode=false;
        noteUpside=new string[]{
            "b2",null,"b2",null,null,null,"d3",null,
            "b2",null,"b2","a2","#f2",null,null,null,
            "a2",null,null,"d3","b2",null,"a2",null,
            "#f2",null,null,null,null,null,null,null,
            "b2",null,"b2",null,null,null,"d3",null,
            "b2",null,"b2","a2","#f2",null,null,null, 
            "a2",null,"#f2","e2_2","d2_2",null,"e2_2",null,
            "a2",null,"#f2",null,null,null,null,null,
            "a2",null,"#f2","a2","#f2",null,null,null,
            "a2",null,"#f2","a2","#f2",null,null,null,
            "e2_2",null,null,null,null,null,null,null,
            "d2_2",null,null,null,null,null,"e2_2",null,
            "#f2","a2","d2_2",null,"e2_2",null,"d2_2",null,
            "b1",null,null,null,null,null,null,null,

            "b2",null,"b2",null,null,null,"d3",null,
            "b2",null,"a2",null,"#f2",null,null,null,
            "a2",null,null,"d3","b2",null,"a2",null,
            "#f2",null,null,null,null,null,null,null,
            "b2",null,"b2",null,null,null,"d3",null,
            "b2",null,"a2",null,"#f2",null,null,null, 
            "a2",null,"#f2","e2_2","d2_2",null,"e2_2",null,
            "#f2",null,null,null,null,null,null,null,
            "a2",null,"#f2","a2","#f2",null,null,null,
            "a2",null,"#f2","a2","#f2",null,null,null,
            "e2_2",null,null,"d2_2","b1",null,"a1",null,
            "d2_2",null,"d2_2",null,null,null,"e2_2",null,
            "#f2","a2","d2_2",null,"e2_2",null,"d2_2",null,
            "b1",null,null,null,null,null,null,null,
            "d2_2",null,null,null,null,null,null,null
            };
            
        noteDownside=new string[]{
            "b","d1","#f1",null,"b1",null, null,null,
            null,null,null,null,"b1","a1","#f1",null,
            "d1",null,null,null,null,null,null,null,
            "b",null,"b1","a1","#f1","d1","b","a",
            "b","d1","#f1",null,"b1",null, null,null,
            "b1",null,null,null,"b1","a1","#f1",null,
            "d1",null,null,null,null,null,null,null,
            "d1","d2_2","b1","a1","#f1","e1","d1","b",
            "a",null,null,null,"a1",null,"#f1","a1",
            "a",null,null,null,"a1",null,"#f1","a1",
            "e1",null,null,"d2_2","b1",null,"a1",null,
            "d1","a","b","d1","#f1",null,"a1",null,
            "#f1",null,"d1",null,"e1",null,"d1",null,
            "b","#f","a","b","d1","e1","#f1","a1",

            "b1","d2_2","#f2","d2_2","#f2","d2_2","a1","d2_2",
            "#f2","d2_2","e2_2","d2_2","d2_2","b1","a1","#f1",
            "#f2","d2_2","#f2","a2","#f2","d2_2","e2_2","b1",
            "d2_2","#f1","a1","b1","d2_2","e2_2","#f2","a2",
            "#f2","d2_2","#f2","d2_2","#f2","d2_2","a2","d2_2",
            "#f2","d2_2","e2_2","d2_2","d2_2","b1","a1","#f1",
            "#f2","e2_2","d2_2","b1","a1","#f1","b1","#f1",
            "d2_2","d1","#f1","a1","b1","d2_2","e2_2","#f2",
            "#f2","e2_2","d2_2","e2_2","d2_2","b1","a1","#f1",
            "#f2","e2_2","d2_2","e2_2","d2_2","b1","a1","#f1",
            "a1","#f1","e1","d1","#f1","e1","d1","b",
            "d1","e1","#f1","a1","b1","a1","#f1","e1",
            "d1","e1","#f1","a1","b1","a1","#f1","d1",
            "b","#f","b","d1","e1","#f1","a1","b1",
            "d","a","b","d1","#f1",null,null,null
            };
    }

    // Update is called once per frame
    void Update()
    {
        if(ActivateMode)
       {
            if(beat<noteUpside.Length && beat==MoveTerm)
            {
                //上行弹奏
                if(noteUpside[beat]!=null||noteDownside[beat]!=null)
                {
                    if(noteUpside[beat]!=null)
                    {
                        //琴弦定位 上行
                        aimedStringUpside=GameObject.Find(noteUpside[beat]);
                        //aimedStringObjectUpside=GameObject.Find(GetCorrectGameObjectName(aimedStringUpside));
                        //highlighterStringUpside=aimedStringObjectUpside.GetComponent<Highlighter>();
                        //highlighterStringUpside.ConstantOn(Color.blue,0.3f);

                        //自动演奏
                        clipPlaying1=aimedStringUpside.GetComponent<ClipPlaying>();
                        
                        TermInClipPlaying1=clipPlaying1.Term;
                        audioSourceTeamInClipPlaying1=clipPlaying1.audioSourceTeam;
                        clipPlaying1.StringPlaying(TermInClipPlaying1, audioSourceTeamInClipPlaying1);

                    }

                    if(noteDownside[beat]!=null)
                    {
                        //下行
                        aimedStringDownside=GameObject.Find(noteDownside[beat]);
                        //aimedStringObjectDownside=GameObject.Find(GetCorrectGameObjectName(aimedStringDownside));
                        //highlighterStringDownside=aimedStringObjectDownside.GetComponent<Highlighter>();
                        //highlighterStringDownside.ConstantOn(Color.green,0.3f);

                        //自动演奏
                        clipPlaying2=aimedStringDownside.GetComponent<ClipPlaying>();

                        TermInClipPlaying2=clipPlaying2.Term;
                        audioSourceTeamInClipPlaying2=clipPlaying2.audioSourceTeam;
                        clipPlaying2.StringPlaying(TermInClipPlaying2, audioSourceTeamInClipPlaying2);                   
                    }

                    //曲谱移动
                    StartCoroutine(WaitAndAddBeat(beatDuration));
                    if(MoveTerm==beat)
                    {
                        NoteSheetUpdate(beat);
                        MoveTerm=MoveTerm+1;

                    }

                }
                else
                {
                    StartCoroutine(WaitAndAddBeat(beatDuration));
                    if(MoveTerm==beat)
                    {
                        NoteSheetUpdate(beat);
                        MoveTerm=MoveTerm+1;
                    }
                }
            }
            else
            {
                Debug.Log("自动演奏！");
                //ActivateMode=false;
            }
        }
        
    }

    public void ClickOnBasicModeButton()
    {
        ActivateMode=true;
        beat=0;
        MoveTerm=0;
        
    }
    public void Exit()
    {
        ActivateMode=false;
        beat=0;
        MoveTerm=0;
    }
    public void Restart()
    {
        beat=0;
        MoveTerm=0;
        beatDuration=0.2f;
    }

    IEnumerator WaitAndAddBeat(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        beat=beat+1;
    }

    private string GetCorrectGameObjectName(GameObject aimedString)
    {
        if(aimedString.name=="a3") return "#f3";
        else if(aimedString.name=="g3") return "e3";
        else if(aimedString.name=="#a2") return "d3";
        else if(aimedString.name=="#g2") return "c3";
        else if(aimedString.name=="f2") return "b2";
        else if(aimedString.name=="#d2") return "a2";
        else if(aimedString.name=="#c2") return "g2";
        else if(aimedString.name=="b1") return "#f2";
        else if(aimedString.name=="a1") return "e2_2";
        else if(aimedString.name=="g1_2") return "d2_2";
        else if(aimedString.name=="f1_2") return "c2_2";
        else if(aimedString.name=="b_e1") return "b_b1";
        else if(aimedString.name=="b_d1") return "b_a1";
        else return aimedString.name;
    }

    private void NoteSheetUpdate(int b)
    {
        if(b<15) NoteSheetMovement(Note1);
        else if(b<47)
        {
            NoteSheetMovement(Note1);
            NoteSheetMovement(Note2);
        }
        else if(b<79)
        {
            NoteSheetMovement(Note1);
            NoteSheetMovement(Note2);
            NoteSheetMovement(Note3);
        }
        else if(b<95)
        {
            NoteSheetMovement(Note2);
            NoteSheetMovement(Note3);
            NoteSheetMovement(Note4);
        }
        else if(b<127)
        {
            NoteSheetMovement(Note3);
            NoteSheetMovement(Note4);
            NoteSheetMovement(Note5);
        }
        else if(b<159)
        {
            NoteSheetMovement(Note4);
            NoteSheetMovement(Note5);
            NoteSheetMovement(Note6);
        }
        else if(b<191)
        {
            NoteSheetMovement(Note5);
            NoteSheetMovement(Note6);
            NoteSheetMovement(Note7);
        }
        else
        {
            NoteSheetMovement(Note6);
            NoteSheetMovement(Note7);
            NoteSheetMovement(Note8);
        }
    }

    private void NoteSheetMovement(GameObject Note)
    {
        CurrentPos=Note.GetComponent<RectTransform>().anchoredPosition;
        if(beat-beat/32*32<=7)
        {
            beatStep = new Vector3(-34.0f,0f,0f);
            beatStepIncreasingFor4=new Vector3(-14.0f,0f,0f);
            beatStepIncreasingFor8=new Vector3(-41.0f,0f,0f);
        }
        else
        {
            beatStep = new Vector3(-37.0f,0f,0f);
            beatStepIncreasingFor4=new Vector3(-11.0f,0f,0f);
            beatStepIncreasingFor8=new Vector3(-38.0f,0f,0f);
        }
        Vector3 TargetPos=CurrentPos+beatStep;
        if(beat!=0&&(beat+1)==(beat+1)/8*8) TargetPos=TargetPos+beatStepIncreasingFor8;      
        else if((beat+1)==(beat+1)/4*4) TargetPos=TargetPos+beatStepIncreasingFor4;
        float beatDistance = Vector3.Distance(CurrentPos, TargetPos);
        tfSpeed=beatDistance/beatDuration;
        Debug.Log("原始anchoredPositionX:"+CurrentPos.x+";更改后的anchoredPositionX:"+TargetPos.x+";beat:"+beat+";距离:"+beatDistance);

        DOTween.To(() => Note.GetComponent<RectTransform>().anchoredPosition3D, x => Note.GetComponent<RectTransform>().anchoredPosition3D = x,TargetPos, beatDuration);
        CurrentPos=TargetPos;
        

    }



}
