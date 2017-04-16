using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mouse : MonoBehaviour {
    

    public Sprite mouseNormal;
    public Sprite mouseDoorHover;
    

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
            EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_HOVER, SetHoverSprite);
            EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_LEAVE, SetNormalSprite);
        }
        //EventManager.Subscribe(EventEnumType.E_EVENT_ID.DOOR_CLICKED, SetNormalSprite);
    }
    void OnDisable()
    {
        if (MultiplatformInput.interactionType == MultiplatformInput.E_INTERACTION_TYPE.MOUSE)
        {
            EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.DOOR_HOVER, SetHoverSprite);
            EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.DOOR_LEAVE, SetNormalSprite);
        }
        //EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.DOOR_CLICKED, SetNormalSprite);
    }




    void SetNormalSprite()
    {
        GetComponent<Image>().sprite = mouseNormal;                
    }
    void SetHoverSprite()
    {
        GetComponent<Image>().sprite = mouseDoorHover;
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

       
}
