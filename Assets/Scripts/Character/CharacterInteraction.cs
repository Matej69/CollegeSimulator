using UnityEngine;
using System.Collections;

public class CharacterInteraction : MonoBehaviour {

    public GameObject ref_pin;

    private CharacterStats characterStats;

    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    




    //Unity script
    void OnEnable()
    {
        EventManager.Subscribe(EventEnumType.E_EVENT_ID.CHAR_CLICKED_ON, ChooseProperController);
    }
    void OnDisable()
    {
        EventManager.Unsubscribe(EventEnumType.E_EVENT_ID.CHAR_CLICKED_ON, ChooseProperController);
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


    






}
