using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterFactory {

    private static CharacterFactory instance;
    static public CharacterFactory Instance()
    {
        if(instance == null)
        {
            instance = new CharacterFactory();
            instance.prefab_char = Resources.Load<GameObject>("Objects/Character/Character");
        }
        return instance;
    }


    private GameObject prefab_char;


    public GameObject GenerateCharacter(CharacterInfo.E_CHAR _charID)
    {
        GameObject newChar = (GameObject)MonoBehaviour.Instantiate(instance.prefab_char);
        newChar.GetComponent<CharacterStatus>().charType = _charID;
        return newChar;
    }

    
    public List<GameObject> GenerateRandCharacters(int _amount)
    {
        List<GameObject> chars = new List<GameObject>();
        for (int i = 0; i < _amount; ++i)
        {
            CharacterInfo.E_CHAR randCharID = (CharacterInfo.E_CHAR)Random.Range(0, (int)CharacterInfo.E_CHAR.SIZE);
            chars.Add(instance.GenerateCharacter(randCharID));            
        }
        return chars;       
    }
    

}
