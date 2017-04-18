using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    public BuildingEnum.E_TYPE roomID;
    public Transform doorPoint;
    public float doorRadius;

    private bool wasMouseOnDoorLastFrame = false;


    void Update()
    {
        HandleMouseToDoorInteraction();
    }



    public bool IsMouseOnDoor()
    {
        float dist = Vector2.Distance(MultiplatformInput.GetInputPos(), doorPoint.transform.position);
        return (dist < doorRadius) ? true : false;
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
