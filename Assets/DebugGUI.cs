using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugGUI : MonoBehaviour {
    
    private static DebugGUI ref_instance;

    public Text ref_text;

    private static int msgID = 0;

    void Awake()
    {
        ref_instance = this;
    }




    static public void WriteText(string _txt)
    {
        if (ref_instance.ref_text.IsActive())
        {
            ref_instance.ref_text.text += "\n" + msgID + ".) " + _txt;
            msgID++;
        }
    }	
}
