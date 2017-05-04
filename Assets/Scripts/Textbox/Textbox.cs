using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Textbox : MonoBehaviour {

    static public bool isTextboxActive = false;
    private static Textbox instance;

    public GameObject ref_content;

    private List<TextboxMessageInfo> messages = new List<TextboxMessageInfo>();

    Timer displayNewLetter;

    Text messageDisplayed;
    Text nextMessage;

    
   
    static public Textbox GetInstance()
    {
        return ((instance != null) ? instance : instance = FindObjectOfType<Textbox>());
    }   

	// Use this for initialization
	void Start () {
        messageDisplayed = ref_content.transform.FindChild("Message").GetComponent<Text>();
        nextMessage = ref_content.transform.FindChild("PressEMessage").GetComponent<Text>();

        displayNewLetter = new Timer(0.055f);        
    }
	
	// Update is called once per frame
	void Update () {

        HandleMessageDisplay();

    }


    void HandleMessageDisplay()
    {
        displayNewLetter.Tick(Time.deltaTime);        
        if(displayNewLetter.IsFinished() && AnyMessagesLeft())
        {            
            if (!messages[0].IsMessageRead())
            {
                nextMessage.enabled = false;
                messages[0].ReadLetter();
                messageDisplayed.text = messages[0].msg;
            } 
            else
            {
                nextMessage.enabled = true;
                if (Input.GetKey(KeyCode.E))
                {
                    messages.RemoveAt(0);
                    if (!AnyMessagesLeft())
                        DisableMessageBox();
                }
            }  

            

            displayNewLetter.Reset();
        }        
    }

    bool AnyMessagesLeft()
    {
        return (messages.Count != 0);
    }
    


    public void EnableMessageBox(List<TextboxMessageInfo> _msgs)
    {
        messages = _msgs;
        ref_content.SetActive(true);
        Textbox.isTextboxActive = true;        
    }    

    void DisableMessageBox()
    {
        ref_content.SetActive(false);
        Textbox.isTextboxActive = false;
    }





}
