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
    }

    public void ReduceStatsValue(E_STATS_ID _id, float _value)
    {
        statsDictionary[_id] = statsDictionary[_id] - _value;
    }

    public void SetStatsValue(E_STATS_ID _id, float _value)
    {
        statsDictionary[_id] = _value;
    }


}
