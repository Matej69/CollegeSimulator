using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour, IVertAxisLayering {

    public BuildingEnum.E_TYPE buildingType;
    public float doorRadius;

    private Transform doorPoint;
    private bool wasMouseOnDoorLastFrame = false;

    void Awake()
    {
        doorPoint = transform.FindChild("doorPoint");
    }

	// Update is called once per frame
	void Update ()
    {
        SetProperLayer();
        HandleMouseToDoorInteraction();        

    }

    public void SetProperLayer()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }

    public bool IsMouseOnDoor()
    {
        float dist = Vector2.Distance(MultiplatformInput.GetInputPos(), doorPoint.transform.position);
        return (dist < doorRadius) ? true : false ;
    }
    

    void HandleMouseToDoorInteraction()
    {
        if (IsMouseOnDoor())
        {
            wasMouseOnDoorLastFrame = true;
            EventManager.TriggerEvent(EventEnumType.E_EVENT_ID.DOOR_HOVER);
            if (MultiplatformInput.GetInputDown())
                EventManager.TriggerEvent(EventEnumType.E_EVENT_ID.DOOR_CLICKED);
        }
        else
        {
            if (wasMouseOnDoorLastFrame)
            {
                EventManager.TriggerEvent(EventEnumType.E_EVENT_ID.DOOR_LEAVE);
                wasMouseOnDoorLastFrame = false;
            }

        }
    }


    public bool IsInDoorRange(GameObject _char)
    {
        float dist = Vector2.Distance(doorPoint.position, _char.transform.position);
        if (dist < doorRadius)
            return true;
        return false;
        
             
    }
    


}
