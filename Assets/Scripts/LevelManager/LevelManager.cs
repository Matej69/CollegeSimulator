using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    static LevelManager ref_lvlManager;

    static int MAX_CHAR = 200;

    public GameObject[] prefab_ground;

    List<GameObject> characters = new List<GameObject>();
    List<GameObject> buildings = new List<GameObject>();
    List<GameObject> ground = new List<GameObject>();

    GameObject controlledCharacter;

    void Awake()
    {
        ref_lvlManager = this;
    }

    // Use this for initialization
    void Start () {
        CreateCharacters(100);
        CreateGround(50, 50, new Vector2(-10,-10));

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //******CREATE STUFF******
    private void CreateCharacters(int _charNum)
    {
        characters = CharacterFactory.Instance().GenerateRandCharacters(_charNum);                
    }

    private void CreateGround(int _xNum, int _yNum, Vector2 startPos)
    {
        //offset is for overlaps so it prevents empty 1px lines(because anti-aliassing is disabled)
        Vector2 groundSize = prefab_ground[0].GetComponent<BoxCollider2D>().size;
        Vector2 groundDistance = new Vector2(groundSize.x - 0.05f, groundSize.y - 0.05f);
        Vector2 spawnPos = startPos;        
        for(int x = 0; x < _xNum; ++x)
            for (int y = 0; y < _yNum; ++y)
            {
                spawnPos = new Vector2(startPos.x + (groundDistance.x * x), startPos.y + (groundDistance.y * y));
                int randID = (Random.Range(0, 5) == 0) ? 1 : 0 ;
                ground.Add((GameObject)Instantiate(prefab_ground[randID], spawnPos, Quaternion.identity));
            }
    }


    //*******REMOVE STUFF*******
    private void RemoveCharacters()
    {
        for(int i = characters.Count - 1; i >= 0; --i)
        {
            Destroy(characters[i]);
            characters.RemoveAt(i);
        }
    }
    private void RemoveBuildings()
    {
        for (int i = buildings.Count - 1; i >= 0; --i)
        {
            Destroy(buildings[i]);
            buildings.RemoveAt(i);
        }
    }
    private void RemoveGround()
    {
        for (int i = ground.Count - 1; i >= 0; --i)
        {
            Destroy(ground[i]);
            ground.RemoveAt(i);
        }
    }


    //********SET CONTROLLED CHARACTER**********
    public void TakeControllOverChar(GameObject _char)
    {
        controlledCharacter = _char;        
    }

}
