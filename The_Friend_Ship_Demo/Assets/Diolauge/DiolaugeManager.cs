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
    public Image PB1;
    public Image PB2;

    //  int mood;
    int currentconvopoint;

    NPC CurrentNPC;

   public bool indio;

    bool p1;
    bool p2;


    public int currentstorymoment;
    [SerializeField] public int p1I { get; set; }
   [SerializeField] public int p2I { get; set; }

    // Start is called before the first frame update


    void Start()
    {
        Sentences = new Queue<string>();
    }

    // Update is called once per frame
    public void Startdio(Diolauge Dio)
    {
        indio = true;
        movement.MovInstance.move = false;
        currentconvopoint = 0;
        anim.SetTrigger("Open");
        currentDiolauge = Dio;
        nameText.text = currentDiolauge.Character_in_Conversation[currentconvopoint].Name;

        expression.sprite = currentDiolauge.Character_in_Conversation[currentconvopoint].expressions[(int)currentDiolauge.currentexpressions[currentconvopoint]];
        Sentences.Clear();

        string[] txtstring = Dio.txtsentences.text.Split('\n');

        foreach (var Sentence in txtstring)
        {
            Sentences.Enqueue(Sentence);
        }
        PB1.color = Color.yellow;
        PB2.color = Color.yellow;
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
        StartCoroutine("Timecolor");

        StartCoroutine(TypeSentence(sentence));
    }
    public void Update()
    {
        if (indio)
        {
            if (Input.GetButtonDown("Submit" + p1I.ToString()))
            {
                p1 = true;
                PB1.color = Color.green;

            }
            if (Input.GetButtonDown("Submit" + p2I.ToString()))
            {
                p2 = true;
                PB2.color = Color.green;

            }
            if (p1 && p2 )
            {

                p1 = false;
                p2 = false;
                DisplayNextSentence();
            }
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
    IEnumerator Timecolor()
    {
        yield return new WaitForSeconds(0.5f);
        PB1.color = Color.yellow;
        PB2.color = Color.yellow;
    }
    void EndDiolauge()
    {
      
            indio = false;
        movement.MovInstance.move = true;

        p1 = false;
            p2 = false;
            //CurrentNPC = null;
            //currentDiolauge = null;
               
            anim.SetTrigger("Close");
           
        
        //else
        //{
        //    anim.SetTrigger("Close");
        //    Debug.Log("end");
        //    return;
        //}


    }

   

    }
