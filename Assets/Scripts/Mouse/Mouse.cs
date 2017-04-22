using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour {
    
    public Sprite mouseNormal;
    public Sprite mouseDoorHover;
    public Sprite mouseInterEntityHover;


    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        FollowMouse();
    }
    //Unity script
    void OnEnable()
    {
        if (MultiplatformInput.interactionType == MultiplatformInput.E_INTERACTION_TYPE.MOUSE)
        {
            EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_HOVER, SetDoorHoverSprite);
            EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_LEAVE, SetNormalSprite);
            EventManager.Subscribe(EventEnumType.E_EVENT_ID.INTERACTABLE_HOVER, SetInterEntityHoverSprite);
            EventManager.Subscribe(EventEnumType.E_EVENT_ID.INTERACTABLE_LEAVE, SetNormalSprite);
        }
        //EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_CLICKED, SetNormalSprite);
    }
    void OnDisable()
    {
        if (MultiplatformInput.interactionType == MultiplatformInput.E_INTERACTION_TYPE.MOUSE)
        {
            EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.DOOR_HOVER, SetDoorHoverSprite);
            EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.DOOR_LEAVE, SetNormalSprite);
            EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.INTERACTABLE_HOVER, SetInterEntityHoverSprite);
            EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.INTERACTABLE_LEAVE, SetNormalSprite);
        }
        //EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.DOOR_CLICKED, SetNormalSprite);
    }




    void SetNormalSprite()
    {
        GetComponent<Image>().sprite = mouseNormal;                
    }
    void SetDoorHoverSprite()
    {
        GetComponent<Image>().sprite = mouseDoorHover;
    }
    void SetInterEntityHoverSprite()
    {
        GetComponent<Image>().sprite = mouseInterEntityHover;
    }

    void FollowMouse()
    {
        transform.position = Camera.main.WorldToScreenPoint(MultiplatformInput.GetInputPos());
    }



    static public void GetBuildingCursorIsOn(out Building _building)
    {
        for(int i = 0; i < LevelManager.ref_lvlManager.buildings.Count; ++i)
        {
            Building curBuilding = LevelManager.ref_lvlManager.buildings[i].GetComponent<Building>();
            if (curBuilding.IsMouseOnDoor())
            {
                _building = curBuilding;
                return;
            }
        }
        _building = null;
    }
    
    static public void GetRoomCursorIsOn(out Room _room)
    {
        for (int i = 0; i < RoomManager.ref_instance.rooms.Count; ++i)
        {
            Room curRoom = RoomManager.ref_instance.rooms[i];
            if (curRoom.IsMouseOnDoor())
            {
                _room = curRoom;
                return;
            }
        }
        _room = null;
    }

    



}
