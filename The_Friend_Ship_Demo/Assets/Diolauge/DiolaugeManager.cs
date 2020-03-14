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
    [SerializeField] Diolauge currentDiolauge;
    public Image PB1;
    public Image PB2;


    public Image Carl;
    public Image Katie;
    public Image Other;

    public TextMeshProUGUI ThingtoDo;

    public string TXTThingtodo;
    public string thingtodo;
    //  int mood;
  public  int currentconvopoint;

    NPC CurrentNPC;


   public bool indio;

    bool p1;
    bool p2;

    bool Ineractobj;
    public int currentstorymoment;
    [SerializeField] public int p1I { get; set; }
   [SerializeField] public int p2I { get; set; }

  [SerializeField]  GameObject currentdiogame;
    // Start is called before the first frame update
   public uimanager mana;

    bool npcintoduced;
    void Start()
    {
        Sentences = new Queue<string>();
        mana = uimanager.UIinstance;
        cam = FindObjectOfType<camscript>();
    }

    // Update is called once per frame
    public void Startdio(Diolauge Dio , GameObject game , bool interact)
    {
        Audiomana.Audioinstance.Play("OneBell");

        indio = true;
        movement.MovInstance.move = false;
        anim.SetTrigger("Open");
        currentDiolauge = Dio;
        nameText.text = currentDiolauge.Character_in_Conversation[currentconvopoint].Name;
        if (Dio.ThingToDoTxt != "") {
            TXTThingtodo = Dio.ThingToDoTxt;
        }
        if (Dio.thingtodo != "") {
            thingtodo = Dio.thingtodo;
        }
    
        Sentences.Clear();

        string[] txtstring = Dio.txtsentences.text.Split('\n');

        foreach (var Sentence in txtstring)
        {
            Sentences.Enqueue(Sentence);
        }
        PB1.color = Color.yellow;
        PB2.color = Color.yellow;
       // Other.sprite = null;

        currentdiogame = game;
        Ineractobj = interact;

        if (currentDiolauge.oneonone && Carl.transform.localScale.x > 0f) {
            Carl.transform.position = Other.transform.position;
            Carl.transform.localScale = new Vector3( -1,1);
            Other.color = Color.clear;

        } else if (!currentDiolauge.oneonone && Carl.transform.localScale.x < 0f) {
            Carl.transform.localPosition = new Vector3(Katie.transform.localPosition.x-335, Katie.transform.localPosition.y);
            Carl.transform.localScale = new Vector3(1, 1);

        }

        DisplayNextSentence();

        if (Ineractobj) {
            currentdiogame.gameObject.SetActive(false);
        } else {
            return;

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

     
        if (currentDiolauge.Character_in_Conversation[currentconvopoint].notNPC) {
            if (currentDiolauge.Character_in_Conversation[currentconvopoint].Name == "Carl") {
                Carl.color = Color.white;
                Katie.color = Color.gray;
                Other.color = Color.gray;
            } else if (currentDiolauge.Character_in_Conversation[currentconvopoint].Name == "Katie") {
                Katie.color = Color.white;
                Carl.color = Color.gray;
                Other.color = Color.gray;
            }

        } else {
           
            Other.sprite = currentDiolauge.Character_in_Conversation[currentconvopoint].expressions[(int)currentDiolauge.currentexpressions[currentconvopoint]];
            npcintoduced = true;
            Other.color = Color.white;
            Katie.color = Color.gray;
            Carl.color = Color.gray;
        }
        if (!npcintoduced) {
            Other.color = Color.clear;
        }
        currentdiogame.SendMessage("Dothing" + currentconvopoint.ToString(), SendMessageOptions.DontRequireReceiver);
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
                PB1.color = uimanager.UIinstance.P1C;

            }
            if (Input.GetButtonDown("Submit" + p2I.ToString()))
            {
                p2 = true;
                PB2.color = uimanager.UIinstance.P2C;

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
        //DioText.text = "";
        DioText.text  = sentence;
        yield return null;
        //foreach (char Letter in sentence.ToCharArray())
        //{
        //    yield return new WaitForSeconds(0.03f);
        //}
    }
    IEnumerator Timecolor()
    {
        yield return new WaitForSeconds(0.5f);
        PB1.color = Color.yellow;
        PB2.color = Color.yellow;
    }
    void EndDiolauge()
    {
        Audiomana.Audioinstance.Play("TwoBells");

        currentconvopoint = 0;

        indio = false;
      
        movement.MovInstance.move = true;

        p1 = false;
            p2 = false;
       // Other.sprite = null;
        //CurrentNPC = null;
        //currentDiolauge = null;
        mana.p1.enabled = true;
        mana.p2.enabled = true;
       
        npcintoduced = false;

        cam.Normal();
    
        ThingtoDo.text = "Thing to do -> " + TXTThingtodo;
        for (int i = 2; i < 6; i++) {
            mana.Menus[i].SetActive(true);
        }

        if (mana.Menus[1].activeSelf && (uimanager.UIinstance.playersready[0] || uimanager.UIinstance.playersready[1])) {

            mana.toggleinvet();
        }

        if (Ineractobj) {
            anim.SetTrigger("Close");

            currentdiogame.gameObject.SetActive(true);
        } else
	{     
            anim.SetTrigger("Close");
            if (thingtodo != "") {
                currentdiogame.SendMessage(thingtodo, SendMessageOptions.DontRequireReceiver);

            }
            thingtodo = "";

        }
        currentdiogame.SendMessage("Fin", SendMessageOptions.DontRequireReceiver);

        currentdiogame = null;

     

    }



}
