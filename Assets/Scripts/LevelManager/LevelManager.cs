using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    /*
    public enum E_LEVEL_STATE
    {
        PLAYING,
        TRAVELING
    }
    E_LEVEL_STATE levelState = E_LEVEL_STATE.PLAYING;
    */

    static public LevelManager ref_lvlManager;
    static int MAX_CHAR = 100;
    static int MAX_DAYS = 30;
    public static int MAX_ECTS = 180;
    static int curDay = 0;

    public GameObject ref_groundHolder;
    public GameObject ref_charactersHolder;

    public GameObject[] prefab_ground;

    public List<GameObject> buildings = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> characters = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> ground = new List<GameObject>();

    [HideInInspector]
    public GameObject controlledCharacter;

    [HideInInspector]
    public BoxCollider2D levelBounds;

    void Awake()
    {
        ref_lvlManager = this;
    }

    // Use this for initialization
    void Start () {
        levelBounds = GetComponent<BoxCollider2D>();
        CreateCharacters(45);
        CreateControlledCharacter();
        CreateGround(68, 100, new Vector2(-45,-20));


    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    //******CREATE STUFF******
    private void CreateCharacters(int _charNum)
    {
        characters = CharacterFactory.Instance().GenerateRandCharacters(_charNum);
        foreach (GameObject character in characters)
        {
            character.transform.parent = ref_charactersHolder.transform;
            character.transform.position = ref_charactersHolder.transform.position;
        }               
    }

    private void CreateControlledCharacter()
    {
        GameObject character = CharacterFactory.Instance().GenerateCharacter(CharacterInfo.E_CHAR.BOY3);
        character.transform.parent = ref_charactersHolder.transform;
        character.transform.position = ref_charactersHolder.transform.position;
        character.GetComponent<CharacterInteraction>().ref_pin.SetActive(true);
        character.GetComponent<CharacterStatus>().SetControlType(AController.E_CHAR_CONTROLER.PLAYER_CONTROL);
        character.GetComponent<CharacterStatus>().SetActionState(CharacterInfo.E_CHAR_ACTION.IDLE);
        LevelManager.ref_lvlManager.controlledCharacter = character;
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
                int randID = (Random.Range(0, 8) == 0) ? 1 : 0 ;
                GameObject newGround = (GameObject)Instantiate(prefab_ground[randID], spawnPos, Quaternion.identity);
                newGround.transform.parent = ref_groundHolder.transform;
                ground.Add(newGround);
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


    //********CONTROLLED CHARACTER**********
    public void TakeControllOverChar(GameObject _char)
    {
        controlledCharacter = _char;        
    }
    public bool IsCharacterControlled()
    {
        return (controlledCharacter != null) ? true : false;
    }

    //******************BOUNDS********************
    public bool IsPosOutOfBounds(Vector2 _pos)
    {
        Vector2 halfSize = levelBounds.size/2;
        Vector2 center = levelBounds.bounds.center;
        if (_pos.x < center.x + halfSize.x && _pos.x > center.x - halfSize.x && _pos.y > center.y - halfSize.y && _pos.y < center.y + halfSize.y)
            return true;
        else
            return false;
    }

    //*****************On new day*****************
    public void OnNewDay()
    {
        curDay++;
        if (curDay >= LevelManager.MAX_DAYS)
            OnGameEnd();
        else
        {
            NewDayText.instance.EnableText((LevelManager.MAX_DAYS - curDay) + " DAYS LEFT ");
            LevelManager.ref_lvlManager.controlledCharacter.GetComponent<CharacterStatus>().statsInfo.AddStatsValue(StatsInfo.E_STATS_ID.ENERGY_MAX, 1);
        }
    }

    private void OnGameEnd()
    {
        EndGame.instance.TriggerEndGame(controlledCharacter.GetComponent<CharacterStatus>().statsInfo);
    }


}
