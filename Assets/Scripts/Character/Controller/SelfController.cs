using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterStatus))]
public class SelfController : AController {

    Rigidbody2D rigid;

    // Use this for initialization
    void Awake()
    {
        characterStats = GetComponent<CharacterStatus>();
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (characterStats.controlType == E_CHAR_CONTROLER.SELF_CONTROL)
            HandleMovement();

    }




    override public void HandleMovement()
    {
        rigid.velocity = Vector2.zero;
    }


}
