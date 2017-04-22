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
    DialogGUIInfoPacket displayedInfoPacket;
    

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
    

    void Update()
    {
        if (IsContentVisible())
        {
            FillGUIWithInfo();
        }
    }

   



    private void ClearGUIInfo()
    {
        ref_text.text = "";
        ref_effects.text = "";
        ref_requirements.text = "";
    }

    public void FillGUIWithInfo()
    {
        ClearGUIInfo();
        ref_text.text = displayedInfoPacket.text;
        foreach (StatAmountPair effect in displayedInfoPacket.effects)
            ref_effects.text += "+ " + effect.amount + " " + StatsInfo.GetEnumString(effect.id) + "\n";
        foreach (StatAmountPair requirement in displayedInfoPacket.requirements)
            ref_requirements.text += "- " + requirement.amount + " " + StatsInfo.GetEnumString(requirement.id) + "\n";
        UpdateUpgradeButtonInteractivity();
    }
    public void SetGUIInfoSource(DialogGUIInfoPacket _infoPacket)
    {
        displayedInfoPacket = _infoPacket;
    }




    private bool AreRequirementsMet()
    {
        StatsInfo charStats = LevelManager.ref_lvlManager.controlledCharacter.GetComponent<CharacterStatus>().statsInfo;
        bool reqFulfil = true;
        foreach (StatAmountPair requirement in displayedInfoPacket.requirements)
            if (requirement.amount > charStats.GetStatsValue(requirement.id))
                reqFulfil = false;
        return reqFulfil;
    }

    private void BuyUpgrade()
    {
        StatsInfo charStats = LevelManager.ref_lvlManager.controlledCharacter.GetComponent<CharacterStatus>().statsInfo;
        foreach (StatAmountPair requirement in displayedInfoPacket.requirements)
            charStats.ReduceStatsValue(requirement.id, requirement.amount);
        foreach (StatAmountPair effect in displayedInfoPacket.effects)
            charStats.AddStatsValue(effect.id, effect.amount);
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

    void UpdateUpgradeButtonInteractivity()
    {
        if (AreRequirementsMet())
            ref_upgradeButton.interactable = true;
        else
            ref_upgradeButton.interactable = false;
    }

    private void SetButtonListeners()
    {
        //upgrade button
        ref_upgradeButton.onClick.AddListener(delegate
        {            
            if (AreRequirementsMet())
                BuyUpgrade();    
        });
        //exit button
        ref_exitButton.onClick.AddListener(delegate
        {
            SetContentVisibility(E_VISIBILITY.INVISIBLE);
        });
    }

}
