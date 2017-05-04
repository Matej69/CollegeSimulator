using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VisibleStatsGUI : MonoBehaviour {

    public Text ref_energyTxt;
    public Text ref_hungerTxt;
    public Text ref_moneyTxt;
    public Text ref_intelligenceTxt;
    public Text ref_socialTxt;
    public Text ref_ECTSTxt;


    void Update ()
    {
        FillGUIWithInfo();        	
	}



    void FillGUIWithInfo()
    {
        if (LevelManager.ref_lvlManager.controlledCharacter != null)
        {
            StatsInfo statsInfo = LevelManager.ref_lvlManager.controlledCharacter.GetComponent<CharacterStatus>().statsInfo;
            ref_energyTxt.text = statsInfo.GetStatsValue(StatsInfo.E_STATS_ID.ENERGY) + "/" + statsInfo.GetStatsValue(StatsInfo.E_STATS_ID.ENERGY_MAX);
            ref_hungerTxt.text = statsInfo.GetStatsValue(StatsInfo.E_STATS_ID.HUNGER) + "/" + statsInfo.GetStatsValue(StatsInfo.E_STATS_ID.HUNGER_MAX);
            ref_moneyTxt.text = statsInfo.GetStatsValue(StatsInfo.E_STATS_ID.MONEY).ToString();
            ref_intelligenceTxt.text = statsInfo.GetStatsValue(StatsInfo.E_STATS_ID.INTELLIGENCE).ToString();
            ref_socialTxt.text = statsInfo.GetStatsValue(StatsInfo.E_STATS_ID.SOCIAL).ToString();
            ref_ECTSTxt.text = statsInfo.GetStatsValue(StatsInfo.E_STATS_ID.ECTS).ToString();
        }
        else
        {
            ref_energyTxt.text = "/";
            ref_hungerTxt.text = "/";
            ref_moneyTxt.text = "/";
            ref_intelligenceTxt.text = "/";
            ref_socialTxt.text = "/";
            ref_ECTSTxt.text = "/";
        }

    }

}
