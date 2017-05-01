using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterStatus))]
public class PlayerController : AController {
           
    struct TravelInfo
    {
        public Vector2 targetTravelPos;
        public Vector2 travelDir;
    }
    TravelInfo travelInfo;

    Rigidbody2D rigid;

    public enum E_MOVEMENT_STATE
    {
        WALK,
        RUN
    }
    private float walkSpeed = 3 * 50;
    private float runSpeed = 10 * 50;
    private float movementSpeed = 3 * 50;

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
        characterStats = GetComponent<CharacterStatus>();
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
            UpdateMovementAttributes();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }



    override public void HandleMovement()
    {
        //travel to target pos if GUI is not visible
        if (characterStats.controlType == E_CHAR_CONTROLER.PLAYER_CONTROL && !DialogBox.ref_instance.IsContentVisible())
            rigid.velocity = (travelInfo.travelDir * Time.deltaTime * movementSpeed);
        //if GUI is visible set traveling velocity to 0
        if (characterStats.controlType == E_CHAR_CONTROLER.PLAYER_CONTROL && DialogBox.ref_instance.IsContentVisible())
            rigid.velocity = Vector2.zero;
    }


    public void UpdateMovementAttributes()
    {
        //Set new targetPos if mouse/finger up
        if (MultiplatformInput.GetInput() && !DialogBox.ref_instance.IsContentVisible())
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

    public void SetMovementSpeed(E_MOVEMENT_STATE _moveState)
    {
        if (_moveState == E_MOVEMENT_STATE.WALK)
            movementSpeed = walkSpeed;
        else if (_moveState == E_MOVEMENT_STATE.RUN)
            movementSpeed = runSpeed;


    }


}
