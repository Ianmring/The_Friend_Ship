using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DioText;

    public Animator anim;

    camscript cam;

    public Queue<string> Sentences;

    public Image expression;
    Diolauge currentDiolauge;
    public Image PB1;
    public Image PB2;
    public TextMeshProUGUI ThingtoDo;

    public string TXTThingtodo;
    //  int mood;
    [SerializeField]
    int currentconvopoint;

    NPC CurrentNPC;

   public bool indio;

    bool p1;
    bool p2;


    public int currentstorymoment;
    [SerializeField] public int p1I { get; set; }
   [SerializeField] public int p2I { get; set; }

    GameObject currentdiogame;
    // Start is called before the first frame update
   public uimanager mana;

    void Start()
    {
        Sentences = new Queue<string>();
        mana = uimanager.UIinstance;
        cam = FindObjectOfType<camscript>();
    }

    // Update is called once per frame
    public void Startdio(Diolauge Dio , GameObject game)
    {

        indio = true;

        movement.MovInstance.move = false;
        currentconvopoint = 0;
        anim.SetTrigger("Open");
        currentDiolauge = Dio;
        nameText.text = currentDiolauge.Character_in_Conversation[currentconvopoint].Name;
        if (Dio.ThingToDoTxt != "") {
            TXTThingtodo = Dio.ThingToDoTxt;
        } 
     //   TXTThingtodo = Dio.ThingToDoTxt;
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
        if (game == null) {
            return;
        } else {
            currentdiogame = game;
            currentdiogame.SetActive(false);
            

        }

        for (int i = 2; i < 6; i++) {
            mana.Menus[i].SetActive(false);
        }

        mana.p1.enabled = false;
        mana.p2.enabled = false;
        if (mana.Menus[1].activeSelf && (uimanager.UIinstance.playersready[0] || uimanager.UIinstance.playersready[1])) {

            mana.toggleinvet();
        }

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
        mana.p1.enabled = true;
        mana.p2.enabled = true;

        cam.isfollwoing = true;
    
        ThingtoDo.text = "Thing to do -> " + TXTThingtodo;

        for (int i = 2; i < 6; i++) {
            mana.Menus[i].SetActive(true);
        }

        if (mana.Menus[1].activeSelf && (uimanager.UIinstance.playersready[0] || uimanager.UIinstance.playersready[1])) {

            mana.toggleinvet();
        }

        if (currentdiogame == null) {
            anim.SetTrigger("Close");

        }
        else
	{
            anim.SetTrigger("Close");

            currentdiogame.SetActive(true);
            currentdiogame.SendMessage("Fin" , SendMessageOptions.DontRequireReceiver);
            currentdiogame = null;

        }
       
       // mana.toggleinvet();


        //else
        //{
        //    anim.SetTrigger("Close");
        //    Debug.Log("end");
        //    return;
        //}


    }



}
