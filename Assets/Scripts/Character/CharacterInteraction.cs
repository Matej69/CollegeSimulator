using UnityEngine;
using System.Collections;

public class CharacterInteraction : MonoBehaviour, IVertAxisLayering {

    public GameObject ref_pin;
    [HideInInspector]
    public Building targetBuilding = null;
    //public BuildingEnum.E_TYPE targetBuilding = BuildingEnum.E_TYPE.LIBRARY;

    private CharacterStats characterStats;

    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
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
            OnInTargetDoorRange();
    }






    void SetTargetBulding(Building _building)
    {
        targetBuilding = _building;        
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
        if (LevelManager.ref_lvlManager.controlledCharacter == gameObject)
            Mouse.GetBuildingCursorIsOn(out targetBuilding);
    }

    public void SetProperLayer()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }

    private void OnInTargetDoorRange()
    {
        //transform.position = RoomManager.ref_instance.GetDoorPoint(targetBuilding.buildingType);
        transform.position = RoomManager.ref_instance.GetDoorPoint(BuildingEnum.E_TYPE.HOUSE);
        MainCamera.ref_cam.transform.position = RoomManager.ref_instance.GetDoorPoint(BuildingEnum.E_TYPE.HOUSE);
    }
    


    






}
