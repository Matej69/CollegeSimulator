using UnityEngine;
using System.Collections;

public class CharacterInteraction : MonoBehaviour, IVertAxisLayering {

    public GameObject ref_pin;
    [HideInInspector]
    public Building targetBuilding = null;
    [HideInInspector]
    public Room targetRoomToLeave = null;
    [HideInInspector]
    public InteractableEntity targetEntity = null;
    bool isInRoom = false;
    //public BuildingEnum.E_TYPE targetBuilding = BuildingEnum.E_TYPE.LIBRARY;

    private CharacterStatus characterStats;

    void Awake()
    {
        characterStats = GetComponent<CharacterStatus>();
    }




    //Unity script
    void OnEnable()
    {
        EventManager.Subscribe(EventEnumType.E_EVENT_ID.CHAR_CLICKED_ON, ChooseProperController);
        EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_CLICKED, OnDoorClicked);        
    }
    void OnDisable()
    {
        EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.CHAR_CLICKED_ON, ChooseProperController);
        EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_CLICKED, OnDoorClicked);
    }
    
    void OnMouseDown()
    {
        //if click => if not selected -> select, if selected -> deselect
        LevelManager.ref_lvlManager.controlledCharacter = (LevelManager.ref_lvlManager.controlledCharacter != gameObject) ? gameObject : null;        
        EventManager.TriggerEvent(EventEnumType.E_EVENT_ID.CHAR_CLICKED_ON);
    }
    void OnMouseEnter()
    {

    }
    void OnMouseExit()
    {

    }
    
    void Update()
    {
        SetProperLayer();
        if(targetBuilding != null && targetBuilding.IsInDoorRange(gameObject))
            OnInOuterTargetDoorRange();
        if (targetRoomToLeave != null && targetRoomToLeave.IsInDoorRange(gameObject))
            OnInInnerTargetDoorRange();
    }






    void SetTargetBulding(Building _building)
    {
        targetBuilding = _building;        
    }
    void SetTargetRoom(Room _room)
    {
        targetRoomToLeave = _room;
    }

    void ChooseProperController()
    {
        if (LevelManager.ref_lvlManager.controlledCharacter == gameObject)
        {
            characterStats.SetControlType(AController.E_CHAR_CONTROLER.PLAYER_CONTROL);
            ref_pin.SetActive(true);
        }
        else
        {
            characterStats.SetControlType(AController.E_CHAR_CONTROLER.SELF_CONTROL);
            characterStats.SetActionState(CharacterInfo.E_CHAR_ACTION.IDLE);
            ref_pin.SetActive(false);
        }
    }

    void OnDoorClicked()
    {
        if (LevelManager.ref_lvlManager.controlledCharacter == gameObject && !isInRoom)        
            Mouse.GetBuildingCursorIsOn(out targetBuilding);      
        else if(LevelManager.ref_lvlManager.controlledCharacter == gameObject && isInRoom)
             Mouse.GetRoomCursorIsOn(out targetRoomToLeave);
    }

    public void SetProperLayer()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }

    private void OnInOuterTargetDoorRange()
    {
        transform.position = RoomManager.ref_instance.GetDoorPoint(targetBuilding.buildingType);
        MainCamera.ref_cam.transform.position = RoomManager.ref_instance.GetDoorPoint(targetBuilding.buildingType);
        isInRoom = true;
    }
    private void OnInInnerTargetDoorRange()
    {       
        transform.position = targetBuilding.doorPoint.position;
        MainCamera.ref_cam.transform.position = targetBuilding.doorPoint.position;        
        targetBuilding = null;
        targetRoomToLeave = null;
        isInRoom = false;       
    }










}
