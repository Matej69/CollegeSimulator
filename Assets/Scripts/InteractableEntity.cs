using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableEntity : MonoBehaviour
{


        
    public string dialog_text;
    public List<DialogBox.StatAmountPair> dialog_effects;
    public List<DialogBox.StatAmountPair> dialog_requirements;
    

    //private DialogBox ref_DialogGUI;
    private bool isDialogCreated;

    public float interactionRadius = 1f;
    private bool wasMouseOnDoorLastFrame = false;





    void Update()
    {
        HandleTargetEntityAssignment();
        HandleMouseToEntityInteraction();   
        HandleDialogGUI();        
    }




    //first we must send data to display and then enable GUI
    protected void EnableDialogGUI()
    {
        DialogBox.DialogGUIInfoPacket dialogPacket = new DialogBox.DialogGUIInfoPacket(dialog_text, dialog_effects, dialog_requirements);
        DialogBox.ref_instance.SetGUIInfoSource(dialogPacket);
        DialogBox.ref_instance.SetContentVisibility(DialogBox.E_VISIBILITY.VISIBLE);
    }
    

    protected bool IsCharInRange(GameObject _otherGo)
    {
        if (_otherGo == null)
            return false;
        float dist = Vector2.Distance(gameObject.transform.position, _otherGo.transform.position);
        if (dist < interactionRadius)
            return true;
        return false;
    }
    protected bool IsMouseOnIteractableEntity()
    {
        float dist = Vector2.Distance(gameObject.transform.position, MultiplatformInput.GetInputPos());
        if (dist < interactionRadius)
            return true;
        return false;
    }




    protected void HandleMouseToEntityInteraction()
    {        
        if (IsMouseOnIteractableEntity())
        {            
            wasMouseOnDoorLastFrame = true;
            EventManager.TriggerEvent(EventEnumType.E_EVENT_ID.INTERACTABLE_HOVER);           
        }
        else
        {
            if (wasMouseOnDoorLastFrame)
            {
                EventManager.TriggerEvent(EventEnumType.E_EVENT_ID.INTERACTABLE_LEAVE);
                wasMouseOnDoorLastFrame = false;
            }
        }        
    }

    protected void HandleDialogGUI()
    {
        CharacterInteraction controlledChar = (LevelManager.ref_lvlManager.controlledCharacter != null) ? LevelManager.ref_lvlManager.controlledCharacter.GetComponent<CharacterInteraction>() : null;
        //creation of dialogBox
        if (controlledChar != null && IsCharInRange(controlledChar.gameObject) && controlledChar.targetEntity == this && !DialogBox.ref_instance.IsContentVisible())
        {            
            EnableDialogGUI();
            controlledChar.targetEntity = null;
        }
    }

    protected void HandleTargetEntityAssignment()
    {
        CharacterInteraction controlledChar = (LevelManager.ref_lvlManager.controlledCharacter != null) ? LevelManager.ref_lvlManager.controlledCharacter.GetComponent<CharacterInteraction>() : null;
        //remove target entity if click somewhere else
        if (!IsMouseOnIteractableEntity() && MultiplatformInput.GetInputDown() && controlledChar != null && controlledChar.targetEntity == this)
        {
            controlledChar.targetEntity = null;
        }
        //set target entity to this entity
        if (IsMouseOnIteractableEntity() && MultiplatformInput.GetInputDown() && controlledChar != null)
        {
            controlledChar.targetEntity = this;
        }
    }
    

}
