using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiolaugeManager : MonoBehaviour
{
    public Text nameText;
    public Text DioText;

    public Animator anim;

    public Queue<string> Sentences;

    public Image expression;
    Diolauge currentDiolauge;

    //  int mood;
    public int currentconvopoint;
    // Start is called before the first frame update
    void Start()
    {
        Sentences = new Queue<string>();
    }

    // Update is called once per frame
    public void Startdio(Diolauge Dio)
    {
        anim.SetTrigger("Open");
        currentDiolauge = Dio;
        nameText.text = currentDiolauge.Character_in_Conversation[currentconvopoint].Name;

        expression.sprite = currentDiolauge.Character_in_Conversation[currentconvopoint].expressions[(int)currentDiolauge.currentexpressions[currentconvopoint]];

        Sentences.Clear();

        foreach (var Sentence in currentDiolauge.Sentences)
        {
            Sentences.Enqueue(Sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if (Sentences.Count == 0)
        {
            EndDiolauge();
            return;
        }
        nameText.text = currentDiolauge.Character_in_Conversation[currentconvopoint].Name;
        expression.sprite = currentDiolauge.Character_in_Conversation[currentconvopoint].expressions[(int)currentDiolauge.currentexpressions[currentconvopoint]];
        currentconvopoint++;

        string sentence = Sentences.Dequeue();


        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        DioText.text = "";
        foreach (char Letter in sentence.ToCharArray())
        {
            DioText.text += Letter;
            yield return new WaitForSeconds(0.03f);
        }
    }

    void EndDiolauge()
    {

        anim.SetTrigger("Close");

    }
}
