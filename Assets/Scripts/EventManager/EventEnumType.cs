using UnityEngine;
using System.Collections;

public class EventEnumType : MonoBehaviour
{

    public enum E_EVENT_ID
    {
        CHAR_CLICKED_ON,
        ROOM_EXITED,
        ROOM_ENTERED,
        BUILDING_LEAVE,
        BUILDING_ENTER,
        CHAR_CONTROLLER_CHANGE,
        DOOR_HOVER,
        DOOR_CLICKED,
        DOOR_LEAVE
    }

	
}
