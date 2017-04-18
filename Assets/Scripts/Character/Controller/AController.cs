using UnityEngine;
using System.Collections;

public abstract class AController : MonoBehaviour {

    protected CharacterStatus characterStats;

    public enum E_CHAR_CONTROLER
    {
        SELF_CONTROL,
        PLAYER_CONTROL
    }

    public enum E_SIDE
    {
        RIGHT,
        LEFT
    }
          
   
    public void Rotate(E_SIDE _side)
    {
        Vector2 scale = transform.localScale;
        scale.x = (_side == E_SIDE.LEFT) ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
    

    public abstract void HandleMovement();


}
