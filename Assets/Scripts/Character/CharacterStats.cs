﻿using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

    [HideInInspector]
    public CharacterInfo.E_CHAR_ACTION actionState;
    public CharacterInfo.E_CHAR charType;
    public AController.E_CHAR_CONTROLER controlType;

    private SelfController selfController;
    private PlayerController playerController;

    void Awake()
    {
        selfController = GetComponent<SelfController>();
        playerController = GetComponent<PlayerController>();
        controlType = AController.E_CHAR_CONTROLER.SELF_CONTROL;
        SetActionState(CharacterInfo.E_CHAR_ACTION.WALKING);
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
