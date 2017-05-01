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
        EventManager.Subscribe(EventEnumType.E_EVENT_ID.CHAR_CLICKED_ON, OnClickedOn);
        EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_CLICKED, OnDoorClicked);        
    }
    void OnDisable()
    {
        EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.CHAR_CLICKED_ON, OnClickedOn);
        EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_CLICKED, OnDoorClicked);
    }
    
    //CAN NOT TAKE CHARACTER CONTROLL IN THIS BUILD
    /*
    void OnMouseDown()
    {
        //if click => if not selected -> select, if selected -> deselect
        if (GetComponent<CharacterStatus>().canBeControlled)
        {
            LevelManager.ref_lvlManager.controlledCharacter = (LevelManager.ref_lvlManager.controlledCharacter != gameObject) ? gameObject : null;
            EventManager.TriggerEvent(EventEnumType.E_EVENT_ID.CHAR_CLICKED_ON);
        }
    }
    */
    
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

    //IF YOU WANT TO TAKE CONTROLL OVER CLICK, FOR CURRENT BUILD OF THE GAME IT IS NOT NECESSARY
    void OnClickedOn()
    {
        
        /*
        if (LevelManager.ref_lvlManager.controlledCharacter == gameObject && GetComponent<CharacterStatus>().canBeControlled)
        {
            characterStats.SetControlType(AController.E_CHAR_CONTROLER.PLAYER_CONTROL);
            ref_pin.SetActive(true);
        }
        else
        {
            characterStats.SetControlType(AController.E_CHAR_CONTROLER.SELF_CONTROL);
            characterStats.SetActionState(CharacterInfo.E_CHAR_ACTION.WALKING);
            ref_pin.SetActive(false);
        }
        */
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
        PlaceChangeBlackScreen.TriggerBlackScreen();
        transform.position = RoomManager.ref_instance.GetDoorPoint(targetBuilding.buildingType);
        MainCamera.ref_cam.transform.position = RoomManager.ref_instance.GetDoorPoint(targetBuilding.buildingType);
        MainCamera.ref_cam.SetCamPlacement(MainCamera.E_CAM_PLACEMENT.ROOM);
        isInRoom = true;
    }
    private void OnInInnerTargetDoorRange()
    {
        PlaceChangeBlackScreen.TriggerBlackScreen();
        transform.position = targetBuilding.doorPoint.position;
        MainCamera.ref_cam.transform.position = targetBuilding.doorPoint.position;
        MainCamera.ref_cam.SetCamPlacement(MainCamera.E_CAM_PLACEMENT.WORLD);
        if(targetRoomToLeave.roomID == BuildingEnum.E_TYPE.HOUSE)
            LevelManager.ref_lvlManager.OnNewDay();
        targetBuilding = null;
        targetRoomToLeave = null;
        isInRoom = false;       
    }










}
