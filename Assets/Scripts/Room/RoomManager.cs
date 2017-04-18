using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour {

    static public RoomManager ref_instance;

    
    public List<Room> rooms;


    void Awake()
    {
        ref_instance = this;
    }
    

    public Vector2 GetDoorPoint(BuildingEnum.E_TYPE _id)
    {
        for (int i = 0; i < rooms.Count; ++i)
            if (rooms[i].roomID == _id)
                return rooms[i].doorPoint.position;
        Debug.LogError("COULD NOT RETURN doorPoint for ID = " + _id);
        return new Vector2(777,777);
    }

    public Room GetRoom(BuildingEnum.E_TYPE _id)
    {
        foreach (Room room in rooms)
            if (room.roomID == _id)
                return room;
        return null;
    }
    

}
