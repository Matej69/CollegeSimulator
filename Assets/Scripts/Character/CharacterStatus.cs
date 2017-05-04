using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour {

    [HideInInspector]
    public CharacterInfo.E_CHAR_ACTION actionState;
    public CharacterInfo.E_CHAR charType;
    public AController.E_CHAR_CONTROLER controlType;

    private SelfController selfController;
    private PlayerController playerController;

    [HideInInspector]
    public StatsInfo statsInfo;

    [HideInInspector]
    public bool canBeControlled = true;

    Timer timer_reduceHunger;
    Timer timer_reduceEnergy;

    void Awake()
    {
        statsInfo = new StatsInfo(40, 30, 0, 0, 5 , 0, 40, 30);

        selfController = GetComponent<SelfController>();
        playerController = GetComponent<PlayerController>();
        controlType = AController.E_CHAR_CONTROLER.SELF_CONTROL;
        SetActionState(CharacterInfo.E_CHAR_ACTION.WALKING);

        timer_reduceHunger = new Timer(3f);
        timer_reduceEnergy = new Timer(1f);
    }
    
    void Update()
    {
        //reduce hunger
        timer_reduceHunger.Tick(Time.deltaTime);
        if (timer_reduceHunger.IsFinished())
        {
            statsInfo.ReduceStatsValue(StatsInfo.E_STATS_ID.HUNGER, 1);
            timer_reduceHunger.Reset();
        }
        //reduce energy when hnger = 0
        if (statsInfo.GetStatsValue(StatsInfo.E_STATS_ID.HUNGER) <= 0)
        {
            timer_reduceEnergy.Tick(Time.deltaTime);
            if (timer_reduceEnergy.IsFinished())
            {
                statsInfo.ReduceStatsValue(StatsInfo.E_STATS_ID.ENERGY, 1);
                timer_reduceEnergy.Reset();
            }
        }




    }

      

    public void SetActionState(CharacterInfo.E_CHAR_ACTION _actionID)
    {
        actionState = _actionID;
    }
    public void SetControlType(AController.E_CHAR_CONTROLER _control)
    {
        controlType = _control;
    }
    

}
