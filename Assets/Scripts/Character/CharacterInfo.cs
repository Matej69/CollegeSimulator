using UnityEngine;
using System.Collections;

public class CharacterInfo : MonoBehaviour {
    
    public enum E_CHAR_ACTION
    {
        IDLE,
        WALKING,
        RUNNING,
        FUN,
        GIFT,
        SIZE
    }    

    public enum E_CHAR
    {
        BOY1,
        BOY2,
        BOY3,
        SIZE
    }
    
    static public float GetAnimationSpeed(E_CHAR_ACTION _actionID)
    {
        switch(_actionID)
        {
            case E_CHAR_ACTION.IDLE :   return 0.04f; break;
            case E_CHAR_ACTION.RUNNING: return 0.03f; break;
            case E_CHAR_ACTION.WALKING: return 0.037f; break;
            case E_CHAR_ACTION.GIFT:    return 0.057f; break;
            case E_CHAR_ACTION.FUN:     return 0.04f; break;
            default:                    return 0.05f; break;
        }
    }
    
    
    	
}
