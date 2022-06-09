using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue3
{
    public List<string> sentences;
}

public class DialogueSystem2 : MonoBehaviour
{
    public Text txtSentence;
    public Dialogue3 info;
    public GameObject catname;
    public GameObject cattext;
    public GameObject bubble;
    public GameObject button;
    public GameObject howto;
 
    Queue<string> sentences = new Queue<string>();

    private void Start()
    {
        Begin(info);
        howto.SetActive(false);
    }

    public void Begin(Dialogue3 info)
    {
        sentences.Clear();
        foreach(var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Next();
    }
    //버튼 클릭 시 다음 대화로 넘어감
    public void Next()
    {
        if(sentences.Count == 0)
        {
            End();
            return;
        }

        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }
    //타이핑 모션 함수
    IEnumerator TypeSentence(string sentence)
    {
        foreach(var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
    //대화 끝
    private void End()
    {
        if (sentences != null)
        {
            catname.SetActive(false);
            cattext.SetActive(false);
            bubble.SetActive(false);
            button.SetActive(false);
            howto.SetActive(true);
            Debug.Log("end");
        }
    }
}