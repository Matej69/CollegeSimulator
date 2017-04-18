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
        ECTS,
        SIZE
    }

    private Dictionary<E_STATS_ID, float> statsDictionary = new Dictionary<E_STATS_ID, float>();




    public StatsInfo()
    {
        for(int i = 0; i < (int)E_STATS_ID.SIZE; ++i)
            statsDictionary[(E_STATS_ID)i] = 0;
    }
    public StatsInfo(float _energy, float _hunger, float _social, float _intel, float _money, float _ects)
    {
        statsDictionary[E_STATS_ID.ENERGY] = _energy;
        statsDictionary[E_STATS_ID.HUNGER] = _hunger;
        statsDictionary[E_STATS_ID.SOCIAL] = _social;
        statsDictionary[E_STATS_ID.INTELLIGENCE] = _intel;
        statsDictionary[E_STATS_ID.MONEY] = _money;
        statsDictionary[E_STATS_ID.ECTS] = _ects;
    }



    public float GetStatsValue(E_STATS_ID _id)
    {
        return statsDictionary[_id];                
    }

    public void AddStatsValue(E_STATS_ID _id, float _value)
    {
        statsDictionary[_id] = statsDictionary[_id] + _value;
    }

    public void SetStatsValue(E_STATS_ID _id, float _value)
    {
        statsDictionary[_id] = _value;
    }


}
