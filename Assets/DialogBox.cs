using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

    [System.Serializable]
    public struct StatAmountPair
    {
        public StatsInfo.E_STATS_ID id;
        public float amount;
    }

    [System.Serializable]
    public class DialogGUIInfoPacket
    {
        public string text;
        public List<StatAmountPair> effects;
        public List<StatAmountPair> requirements;
        public DialogGUIInfoPacket(string _text, List<StatAmountPair> _effects, List<StatAmountPair> _requirements)
        {
            text = _text;    effects = _effects;    requirements = _requirements;
        }
    }
    

    public enum E_VISIBILITY
    {
        VISIBLE,
        INVISIBLE
    }

    public GameObject ref_content;
    public Text ref_text;
    public Text ref_effects;
    public Text ref_requirements;

    public Button ref_upgradeButton;
    public Button ref_exitButton;

    static public DialogBox ref_instance;

    void Awake()
    {
        ref_instance = this;
        SetButtonListeners();
    }

   



    private void ClearGUIInfo()
    {
        ref_text.text = "";
        ref_effects.text = "";
        ref_requirements.text = "";
    }

    public void FillWithInfo(DialogGUIInfoPacket _dialogPacket)
    {
        ClearGUIInfo();
        ref_text.text = _dialogPacket.text;
        foreach (StatAmountPair effect in _dialogPacket.effects)
            ref_effects.text += "+ " + effect.amount + " " + effect.id + "\n";
        foreach (StatAmountPair requirements in _dialogPacket.requirements)
            ref_requirements.text += "- " + requirements.amount + " " + requirements.id + "\n";
    }



    public bool IsContentVisible()
    {
        return ref_content.active;
    }
	
    public void SetContentVisibility(E_VISIBILITY _state)
    {
        if (_state == E_VISIBILITY.VISIBLE)
            ref_content.SetActive(true);
        else
            ref_content.SetActive(false);
    }

    private void SetButtonListeners()
    {
        //upgrade button
        ref_upgradeButton.onClick.AddListener(delegate
        {
            //if every requirement is met -> upgrade every controlled character effect by it's amount

        });

        //exit button
        ref_exitButton.onClick.AddListener(delegate
        {
            SetContentVisibility(E_VISIBILITY.INVISIBLE);
        });
    }

}
