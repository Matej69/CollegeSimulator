﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterStats))]
public class PlayerController : AController {
           
    struct TravelInfo
    {
        public Vector2 targetTravelPos;
        public Vector2 travelDir;
    }
    TravelInfo travelInfo;

    Rigidbody2D rigid;

    private float walkSpeed = 3 * 50;
    private float runSpeed = 10 * 50;

    //Unity script
    void OnEnable()
    {
        //EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_CLICKED, ChooseProperController);
    }
    void OnDisable()
    {
        //EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.DOOR_CLICKED, ChooseProperController);
    }


    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
        rigid = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start ()
    {
        travelInfo.travelDir = Vector2.zero;	
	}	
	// Update is called once per frame
	void Update ()
    {
        if (characterStats.controlType == E_CHAR_CONTROLER.PLAYER_CONTROL)
            HandleMovement();        
    }

    void FixedUpdate()
    {
        //travel to target pos
        if (characterStats.controlType == E_CHAR_CONTROLER.PLAYER_CONTROL)
            rigid.velocity = (travelInfo.travelDir * Time.deltaTime * walkSpeed);
    }






    override public void HandleMovement()
    {
        //Set new targetPos if mouse/finger up
        if (MultiplatformInput.GetInput())
        {
            characterStats.SetActionState(CharacterInfo.E_CHAR_ACTION.WALKING);
            travelInfo.targetTravelPos = MultiplatformInput.GetInputPos();
            travelInfo.travelDir = (travelInfo.targetTravelPos - (Vector2)transform.position).normalized;
            //handle rotation
            if (MultiplatformInput.GetInputPos().x < transform.position.x)
                Rotate(E_SIDE.LEFT);
            else if (MultiplatformInput.GetInputPos().x > transform.position.x)
                Rotate(E_SIDE.RIGHT);            
        }
        //travel to that pos
        //rigid.velocity = (travelInfo.travelDir * Time.deltaTime * walkSpeed);
        //transform.Translate(travelInfo.travelDir * Time.deltaTime * walkSpeed);
        //check if we reached target position                                                
        if (Vector2.Distance(travelInfo.targetTravelPos, transform.position) < 0.05f)
        {
            travelInfo.travelDir = Vector2.zero;
            transform.position = travelInfo.targetTravelPos;
            characterStats.SetActionState(CharacterInfo.E_CHAR_ACTION.IDLE);
        }
    }


}
