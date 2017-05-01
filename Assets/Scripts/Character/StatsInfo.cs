using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatsInfo {

    public enum E_STATS_ID
    {
        ENERGY,
        HUNGER,
        SOCIAL,
        INTELLIGENCE,
        MONEY,
        ENERGY_UPGRADE_LVL,
        HUNGER_UPGRADE_LVL,
        SOCIAL_UPGRADE_LVL,
        INTELLIGENCE_UPGRADE_LVL,
        MONEY_UPGRADE_LVL,
        ECTS, 
        ENERGY_MAX,
        HUNGER_MAX,
        SIZE
    }

    public Dictionary<E_STATS_ID, float> statsDictionary = new Dictionary<E_STATS_ID, float>();




    public StatsInfo()
    {
        for(int i = 0; i < (int)E_STATS_ID.SIZE; ++i)
            if(i >= (int)E_STATS_ID.ENERGY_UPGRADE_LVL && i <= (int)E_STATS_ID.MONEY_UPGRADE_LVL)
                statsDictionary[(E_STATS_ID)i] = 1;
            else
                statsDictionary[(E_STATS_ID)i] = 0;
    }
    public StatsInfo(float _energy, float _hunger, float _social, float _intel, float _money, float _ects, float _maxEnergy, float _maxHunger)
    {
        statsDictionary[E_STATS_ID.ENERGY] = _energy;
        statsDictionary[E_STATS_ID.HUNGER] = _hunger;
        statsDictionary[E_STATS_ID.SOCIAL] = _social;
        statsDictionary[E_STATS_ID.INTELLIGENCE] = _intel;
        statsDictionary[E_STATS_ID.MONEY] = _money;
        statsDictionary[E_STATS_ID.ECTS] = _ects;
        statsDictionary[E_STATS_ID.HUNGER_MAX] = _maxHunger;
        statsDictionary[E_STATS_ID.ENERGY_MAX] = _maxEnergy;
        //set all upgrade values to 1
        for (int i = (int)E_STATS_ID.ENERGY_UPGRADE_LVL; i <= (int)E_STATS_ID.MONEY_UPGRADE_LVL; ++i)
            statsDictionary[(E_STATS_ID)i] = 1;
    }
    


    public float GetStatsValue(E_STATS_ID _id)
    {
        return statsDictionary[_id];                
    }

    public void AddStatsValue(E_STATS_ID _id, float _value)
    {
        statsDictionary[_id] = statsDictionary[_id] + _value;
        if (_id == E_STATS_ID.HUNGER && statsDictionary[_id] > statsDictionary[E_STATS_ID.HUNGER_MAX])
            statsDictionary[_id] = statsDictionary[E_STATS_ID.HUNGER_MAX];
        if (_id == E_STATS_ID.ENERGY && statsDictionary[_id] > statsDictionary[E_STATS_ID.ENERGY_MAX])
            statsDictionary[_id] = statsDictionary[E_STATS_ID.ENERGY_MAX];


    }

    public void ReduceStatsValue(E_STATS_ID _id, float _value)
    {
        float targetValue = statsDictionary[_id] - _value;
        statsDictionary[_id] = (targetValue < 0) ? 0 : targetValue;
    }

    public void SetStatsValue(E_STATS_ID _id, float _value)
    {
        statsDictionary[_id] = _value;
    }


    static public string GetEnumString(E_STATS_ID _statID)
    {
        switch(_statID)
        {
            case E_STATS_ID.ENERGY:                     return "ENERGY"; break;
            case E_STATS_ID.HUNGER:                     return "HUNGER"; break;
            case E_STATS_ID.SOCIAL:                     return "SOCIAL"; break;
            case E_STATS_ID.INTELLIGENCE:               return "INTELLIGENCE"; break;
            case E_STATS_ID.MONEY:                      return "MONEY"; break;
            case E_STATS_ID.ENERGY_UPGRADE_LVL:         return "ENERGY UPGRADE LVL"; break;
            case E_STATS_ID.HUNGER_UPGRADE_LVL:         return "HUNGER UPGRADE LVL"; break;
            case E_STATS_ID.SOCIAL_UPGRADE_LVL:         return "SOCIAL UPGRADE LVL"; break;
            case E_STATS_ID.INTELLIGENCE_UPGRADE_LVL:   return "INTELLIGENCE UPGRADE LVL";  break;
            case E_STATS_ID.MONEY_UPGRADE_LVL:          return "MONEY UPGRADE LVL"; break;
            case E_STATS_ID.ECTS :                      return "ECTS"; break;
            case E_STATS_ID.ENERGY_MAX:                 return "MAX ENERGY"; break;
            case E_STATS_ID.HUNGER_MAX:                 return "MAX HUNGER"; break;
            default: return " -- DEAFULT ENUM -- "; break;
        }
    }


    static public bool IsNormalStats(E_STATS_ID _id)
    {
        if (_id == E_STATS_ID.ENERGY || _id == E_STATS_ID.HUNGER || _id == E_STATS_ID.INTELLIGENCE || _id == E_STATS_ID.MONEY || _id == E_STATS_ID.SOCIAL)
            return true;
        return false;
    }
    static public bool IsUpgradeStats(E_STATS_ID _id)
    {
        if (_id == E_STATS_ID.ENERGY_UPGRADE_LVL || _id == E_STATS_ID.HUNGER_UPGRADE_LVL || _id == E_STATS_ID.INTELLIGENCE_UPGRADE_LVL || 
            _id == E_STATS_ID.MONEY_UPGRADE_LVL || _id == E_STATS_ID.SOCIAL_UPGRADE_LVL)
            return true;
        return false;
    }




}
