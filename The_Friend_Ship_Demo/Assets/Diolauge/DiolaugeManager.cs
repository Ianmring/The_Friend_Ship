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

   public  Character Boy;
   public Character Girl;
    public Queue<string> Sentences;

    public Image expression;
    [SerializeField] Diolauge currentDiolauge;
    public Image PB1;
    public Image PB2;


    public Image Carl;
    public Image Katie;
    public Image Other;

    [SerializeField]
    Image Ridiochat;
   // public TextMeshProUGUI ThingtoDo;

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
    [SerializeField] public int p1I;
    [SerializeField] public int p2I;

    [SerializeField] public string p1C;
    [SerializeField] public string p2C;

    [SerializeField]  GameObject currentdiogame;
    // Start is called before the first frame update
   public uimanager mana;

    bool npcintoduced;

    bool indoor;


    bool playedsfx;


    // public bool soloD;
    void Start()
    {
        Sentences = new Queue<string>();
        mana = uimanager.UIinstance;
        cam = FindObjectOfType<camscript>();
    }

    // Update is called once per frame
    public void Startdio(Diolauge Dio , GameObject game , bool interact , bool indoors)
    {
        Audiomana.Audioinstance.Play("OneBell");
        currentconvopoint = 0;
        indio = true;
        movement.MovInstance.move = false;
        anim.SetTrigger("Open");
        currentDiolauge = Dio;
        nameText.text = currentDiolauge.Lines[currentconvopoint].character.name;
        Katie.overrideSprite = Girl.expressions[0];
        Carl.overrideSprite = Boy.expressions[0];
        if (Dio.ThingToDoTxt != "") {
            TXTThingtodo = Dio.ThingToDoTxt;
        }
        if (Dio.thingtodo != "") {
            thingtodo = Dio.thingtodo;
        }
    
        Sentences.Clear();


        //string[] txtstring = Dio.txtsentences.text.Split('\n');


        foreach (var Sentence in Dio.Lines)
        {
            Sentences.Enqueue(Sentence.line);
        }
        PB1.color = Color.yellow;
        PB2.color = Color.yellow;
       // Other.sprite = null;

        currentdiogame = game;
        Ineractobj = interact;
        indoor = indoors;
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
        nameText.text = currentDiolauge.Lines[currentconvopoint].character.name;


        if (currentDiolauge.Lines[currentconvopoint].character.notNPC) {

            if (currentDiolauge.Lines[currentconvopoint].character.Name == "Carl") {
                    Carl.overrideSprite = currentDiolauge.Lines[currentconvopoint].character.expressions[(int)currentDiolauge.Lines[currentconvopoint].currentexpressions];

                Carl.color = Color.white;
                Katie.color = Color.gray;


            } else if (currentDiolauge.Lines[currentconvopoint].character.Name == "Katie") {
                   Katie.overrideSprite = currentDiolauge.Lines[currentconvopoint].character.expressions[(int)currentDiolauge.Lines[currentconvopoint].currentexpressions];

                Katie.color = Color.white;
                Carl.color = Color.gray;

            }
            Other.color = Color.gray;

        } else {
           
            npcintoduced = true;
            if (currentDiolauge.Lines[currentconvopoint].character == null) {
                Katie.color = Color.gray;
                Carl.color = Color.gray;
                Other.color = Color.clear;

            } else {
                Other.overrideSprite = currentDiolauge.Lines[currentconvopoint].character.expressions[(int)currentDiolauge.Lines[currentconvopoint].currentexpressions];

                if (currentDiolauge.Radio_Characters.Length > 0) {
                    foreach (var item in currentDiolauge.Radio_Characters) {
                        if (currentDiolauge.Lines[currentconvopoint].character == item) {
                            Ridiochat.gameObject.SetActive(true);
                        } else {
                            Ridiochat.gameObject.SetActive(false);
                        }
                    }
                }
                Other.color = Color.white;

                Katie.color = Color.gray;
                Carl.color = Color.gray;
            }
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
            if (Input.GetButtonDown(movement.MovInstance.controllerL + "Submit" + p1I.ToString()))
            {

                if (!playedsfx) {
                    Audiomana.Audioinstance.Play("CasaHover");
                    playedsfx = true;
                }

                p1 = true;

                if (movement.MovInstance.Solo) {
                    p2 = true;
                    PB2.color = uimanager.UIinstance.P2C;
                     
                }
                PB1.color = uimanager.UIinstance.P1C;

            }
            if (Input.GetButtonDown(movement.MovInstance.controllerL+"Submit" + p2I.ToString()))
            {
                if (!playedsfx) {
                    Audiomana.Audioinstance.Play("CasaHover");
                    playedsfx = true;
                }
                p2 = true;
                if (movement.MovInstance.Solo) {
                    p1 = true;
                    PB1.color = uimanager.UIinstance.P1C;

                }
                PB2.color = uimanager.UIinstance.P2C;

            }
            if (p1 && p2 )
            {

                p1 = false;
                p2 = false;
                Audiomana.Audioinstance.Play("CasaSelect");
                playedsfx = false;
                DisplayNextSentence();
            }
        }
       
    }
    IEnumerator TypeSentence(string sentence)
    {
        //DioText.text = "";
       // DioText.text  = sentence;
        DioText.text = "";
        foreach (char Letter in sentence.ToCharArray()) {
            DioText.text += Letter;
            yield return new WaitForSeconds(0.01f);
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
        Audiomana.Audioinstance.Play("TwoBells");

        currentconvopoint = 0;

        indio = false;

            movement.MovInstance.move = true;

        Ridiochat.gameObject.SetActive(false);


        p1 = false;
            p2 = false;
       // Other.sprite = null;
        //CurrentNPC = null;
        //currentDiolauge = null;
        mana.p1.enabled = true;
        mana.p2.enabled = true;
       
        npcintoduced = false;
        if (!indoor) {
            cam.Normal();

        }

        // ThingtoDo.text = "Thing to do -> " + TXTThingtodo;
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
