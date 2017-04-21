using UnityEngine;
using System.Collections;

public class PeopleGroup : MonoBehaviour {
    
    private Vector2[] charPositions;
    private float distance = 0.55f;

	// Use this for initialization
	void Start () {  
        charPositions = new Vector2[]
        {
            new Vector2(transform.position.x - distance + 0.1f, transform.position.y - distance),
            new Vector2(transform.position.x + distance + 0.1f, transform.position.y + distance + 0.25f),
            new Vector2(transform.position.x - distance - 0.2f, transform.position.y + distance),
            new Vector2(transform.position.x + distance, transform.position.y - distance - 0.3f )
        };

        CreateCharacters();
    }
	

    void CreateCharacters()
    {
        int numOfPeople = Random.Range(2, 5);
        for (int i = 0; i < numOfPeople; ++i)
        {            
            int posID = i % charPositions.Length;
            CharacterInfo.E_CHAR randCharID = (CharacterInfo.E_CHAR)Random.Range(0, (int)CharacterInfo.E_CHAR.SIZE);
            GameObject newChar = CharacterFactory.Instance().GenerateCharacter(randCharID);
            newChar.GetComponent<CharacterStatus>().SetActionState(CharacterInfo.E_CHAR_ACTION.IDLE);
            newChar.GetComponent<CharacterStatus>().canBeControlled = false;
            newChar.GetComponent<AController>().Rotate((AController.E_SIDE)Random.Range(0,2));
            newChar.transform.SetParent(transform);
            newChar.transform.position = charPositions[posID];
            
        }
        
    }

	// Update is called once per frame
	void Update () {
	
	}
}
