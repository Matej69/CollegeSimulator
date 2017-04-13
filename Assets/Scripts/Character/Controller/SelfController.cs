using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterStats))]
public class SelfController : AController {

	// Use this for initialization
	void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (characterStats.controlType == E_CHAR_CONTROLER.SELF_CONTROL)
            HandleMovement();

    }




    override public void HandleMovement()
    {
                
    }


}
