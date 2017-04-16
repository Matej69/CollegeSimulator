using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour {

    static public RoomManager ref_instance;

    [System.Serializable]
    public struct RoomInfo
    {
        public BuildingEnum.E_TYPE id;
        public Transform doorPoint;
    }
    
    public List<RoomInfo> rooms;


    void Awake()
    {
        ref_instance = this;
    }
    

    public Vector2 GetDoorPoint(BuildingEnum.E_TYPE _id)
    {
        for (int i = 0; i < rooms.Count; ++i)
            if (rooms[i].id == _id)
                return rooms[i].doorPoint.position;
        Debug.LogError("COULD NOT RETURN doorPoint for ID = " + _id);
        return new Vector2(777,777);
    }
    

}
