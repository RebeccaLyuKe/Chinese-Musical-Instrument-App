using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class BasicLearningModeUpside : MonoBehaviour
{
    public bool ActivateMode;
    private int beat;
    private int MoveTerm;
    private float beatDuration=0.25f;
    private string[] note;
    private GameObject aimedString;
    private GameObject aimedStringObject;
    private Highlighter highlighterString;
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
    Vector2 m_screenPos = new Vector2();
    //CanvasGroup canvasGroup;
    public GameObject button;
    public Sprite SpriteOn;
    public Sprite SpriteOff;
    Button btn;
    public BasicLearningModeDownside basicLearningModeDownside=null;
    public BasicLearningModeWhole basicLearningModeWhole=null;



    // Start is called before the first frame update
    void Start()
    {
        basicLearningModeWhole=this.GetComponent<BasicLearningModeWhole>();
        basicLearningModeDownside=this.GetComponent<BasicLearningModeDownside>();        

        beat=0;
        MoveTerm=0;
        ActivateMode=false;
        note=new string[]{
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
            btn=button.GetComponent<Button>();
    }

    void Awake()
    {
        //this.InvokeRepeating("RunEveryBeat",0f,beatDuration+0.02f);
        Input.multiTouchEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(ActivateMode)
       {
            if(beat<note.Length&&beat==MoveTerm)
            {
                if(note[beat]!=null)
                {
                    //琴弦定位
                    aimedString=GameObject.Find(note[beat]);
                    aimedStringObject=GameObject.Find(GetCorrectGameObjectName(aimedString));
                    highlighterString=aimedStringObject.GetComponent<Highlighter>();
                    highlighterString.ConstantOn(Color.blue);
                    
                    //测试点击
                    if(Input.touchCount==1||Input.touchCount==2)
                    {
                        if (Input.touches[0].phase == TouchPhase.Began)
                        {
                            m_screenPos = Input.touches[0].position;
                            Ray ray = Camera.main.ScreenPointToRay(m_screenPos);
                            RaycastHit hitInfo=new RaycastHit();
                            if(Physics.Raycast(ray, out hitInfo))
                            {
                                if(hitInfo.collider.transform.name==aimedString.name)
                                {
                                    highlighterString.ConstantOff(0.1f);
                                    StartCoroutine(WaitAndAddBeat(beatDuration));
                                    if(MoveTerm==beat)
                                    {
                                    NoteSheetUpdate(beat);
                                    MoveTerm=MoveTerm+1;

                                    }  
                                }
                                else
                                {
                                    highlighterString.ConstantOn(Color.red,3f);
                                }
                            }                       
                        }
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
                Debug.Log("学习完成！");
                //ActivateMode=false;
            }
        }

    }

    public void ClickOnBasicModeButton()
    {

        if(!ActivateMode)
        {
            //开启模式
            ActivateMode=true;
            Debug.Log("上行ActivateMode:"+ActivateMode);
            btn.GetComponent<Image>().sprite=SpriteOn;
            basicLearningModeDownside.ForcedExitAndChangeButton();
            basicLearningModeWhole.ForcedExitAndChangeButton();

        }
        else
        {
            ForcedExitAndChangeButton();
        }
    }

    public void ForcedExitAndChangeButton()
    {
        ActivateMode=false;
        Debug.Log("上行ActivateMode:"+ActivateMode);
        btn.GetComponent<Image>().sprite=SpriteOff;
        if(highlighterString!=null) highlighterString.Off();
        beat=0;
        MoveTerm=0;

    }

    public void Restart()
    {
        beat=0;
        MoveTerm=0;
        if(highlighterString!=null) highlighterString.Off();
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
