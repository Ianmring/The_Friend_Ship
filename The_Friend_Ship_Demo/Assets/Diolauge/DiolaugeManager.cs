using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiolaugeManager : MonoBehaviour
{
        #region Singelton
    public static DiolaugeManager DioInstance;

    private void Awake()
    {
        DioInstance
 = this;
    }
    #endregion
    public Text nameText;
    public Text DioText;

    public Animator anim;

    public Queue<string> Sentences;

    public Image expression;
    Diolauge currentDiolauge;

    //  int mood;
    int currentconvopoint;

    NPC CurrentNPC;

   public bool indio;
    // Start is called before the first frame update
    void Start()
    {
        Sentences = new Queue<string>();
    }

    // Update is called once per frame
    public void Startdio(Diolauge Dio, NPC StartNPC)
    {
        movement.MovInstance.altoveride = true;
        indio = true;
        currentconvopoint = 0;
        anim.SetTrigger("Open");
        CurrentNPC = StartNPC;
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
    public void Update()
    {
        if ((Input.GetButtonDown("Submit1") || (Input.GetButtonDown("Submit2") && indio)))
        {
            DisplayNextSentence();
        }
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
        if (CurrentNPC != null)
        {
            if (CurrentNPC.npctype == NPC.NPCTYPE.NPC && CurrentNPC.missionDone && !CurrentNPC.missionclosed)
            {
                CurrentNPC.Endmission();
            }
            else if (CurrentNPC.npctype == NPC.NPCTYPE.NPC && !CurrentNPC.missionDone && !CurrentNPC.missionclosed)
            {
                CurrentNPC.StartAMission();
               
            }

            indio = false;
            //CurrentNPC = null;
            //currentDiolauge = null;
            anim.SetTrigger("Close");

        }
        else
        {
            anim.SetTrigger("Close");

            return;
        }
        movement.MovInstance.altoveride = false;


    }
}
