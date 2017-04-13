using UnityEngine;
using System.Collections;

public class GraphicsResources : MonoBehaviour {

    void Start()
    {
        CharacterFactory.Instance().GenerateRandCharacters(1);
    }

    //GET CHARACTER SPRITES
    static private string GetCharFolder(CharacterInfo.E_CHAR _id)
    {
        if (_id == CharacterInfo.E_CHAR.BOY1) return "Boy1";
        if (_id == CharacterInfo.E_CHAR.BOY2) return "Boy2";
        if (_id == CharacterInfo.E_CHAR.BOY3) return "Boy3";
        Debug.LogError("THERE IS NO CHAR FOLDER WITH NAME =" +_id);
        return null;
    }
    static private string GetCharAnimFolder(CharacterInfo.E_CHAR_ACTION _id)
    {
        if (_id == CharacterInfo.E_CHAR_ACTION.IDLE) return "idle";
        if (_id == CharacterInfo.E_CHAR_ACTION.WALKING) return "walk";
        if (_id == CharacterInfo.E_CHAR_ACTION.RUNNING) return "run";
        if (_id == CharacterInfo.E_CHAR_ACTION.FUN) return "fun";
        if (_id == CharacterInfo.E_CHAR_ACTION.GIFT) return "gift";
        Debug.LogError("THERE IS NO ANIMATION FOLDER WITH NAME =" + _id);
        return null;
    }
    static public Sprite[] GetCharSprites(CharacterInfo.E_CHAR _charID, CharacterInfo.E_CHAR_ACTION _animID)
    {
        return Resources.LoadAll<Sprite>("Graphics/Characters/" + GetCharFolder(_charID) + "/" + GetCharAnimFolder(_animID));
    }


}
