using UnityEngine;
using System.Collections;

public class CharacterInteraction : MonoBehaviour {

    private CharacterStats characterStats;

    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




    //Unity script
    void OnMouseDown()
    {
        //Send event to LevelManager that it needs to set this player to targeted one, focus cam on that player
        MainCamera.ref_cam.SetCharToFollow(gameObject);
        //Send event to change controll type to new controled char but also to prev char whic is not already controled
        characterStats.SetControlType(AController.E_CHAR_CONTROLER.PLAYER_CONTROL);
    }
    void OnMouseEnter()
    {

    }
    void OnMouseExit()
    {

    }


}
