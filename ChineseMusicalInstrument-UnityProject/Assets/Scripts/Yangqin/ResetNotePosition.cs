using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNotePosition : MonoBehaviour
{
    public GameObject Note1;
    public GameObject Note2;
    public GameObject Note3;
    public GameObject Note4;
    public GameObject Note5;
    public GameObject Note6;
    public GameObject Note7;
    public GameObject Note8;
    private Vector3 note1OriginalPos;
    private Vector3 note2OriginalPos;
    private Vector3 note3OriginalPos;
    private Vector3 note4OriginalPos;
    private Vector3 note5OriginalPos;
    private Vector3 note6OriginalPos;
    private Vector3 note7OriginalPos;
    private Vector3 note8OriginalPos;
    // Start is called before the first frame update
    void Start()
    {
        note1OriginalPos=Note1.GetComponent<RectTransform>().anchoredPosition;
        note2OriginalPos=Note2.GetComponent<RectTransform>().anchoredPosition;
        note3OriginalPos=Note3.GetComponent<RectTransform>().anchoredPosition;
        note4OriginalPos=Note4.GetComponent<RectTransform>().anchoredPosition;
        note5OriginalPos=Note5.GetComponent<RectTransform>().anchoredPosition;
        note6OriginalPos=Note6.GetComponent<RectTransform>().anchoredPosition;
        note7OriginalPos=Note7.GetComponent<RectTransform>().anchoredPosition;
        note8OriginalPos=Note8.GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    public void ResetNotePos()
    {
        Note1.GetComponent<RectTransform>().anchoredPosition=note1OriginalPos;
        Note2.GetComponent<RectTransform>().anchoredPosition=note2OriginalPos;
        Note3.GetComponent<RectTransform>().anchoredPosition=note3OriginalPos;
        Note4.GetComponent<RectTransform>().anchoredPosition=note4OriginalPos;
        Note5.GetComponent<RectTransform>().anchoredPosition=note5OriginalPos;
        Note6.GetComponent<RectTransform>().anchoredPosition=note6OriginalPos;
        Note7.GetComponent<RectTransform>().anchoredPosition=note7OriginalPos;
        Note8.GetComponent<RectTransform>().anchoredPosition=note8OriginalPos;
    }
}
