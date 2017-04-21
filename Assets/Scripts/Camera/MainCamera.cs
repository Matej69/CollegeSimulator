using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public enum E_CAM_PLACEMENT
    {
        WORLD,
        ROOM
    }
    E_CAM_PLACEMENT camPlacement = E_CAM_PLACEMENT.WORLD;


    static public MainCamera ref_cam;
    
    private float followSpeed = 3f;


    void Awake()
    {
        ref_cam = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (LevelManager.ref_lvlManager.controlledCharacter)
        {
            FollowPlayer();
        }
        else
        {
            if (MultiplatformInput.interactionType == MultiplatformInput.E_INTERACTION_TYPE.MOUSE && Input.GetMouseButton(2) && LevelManager.ref_lvlManager.IsPosOutOfBounds(MultiplatformInput.GetInputPos()))
                FollowMouse();
            else if (MultiplatformInput.interactionType == MultiplatformInput.E_INTERACTION_TYPE.FINGER && MultiplatformInput.GetInput())
                FollowMouse();
        }
	}



    private void FollowPlayer()
    {
        Vector2 possibleCamPos = Vector2.Lerp(transform.position, LevelManager.ref_lvlManager.controlledCharacter.transform.position, followSpeed * Time.deltaTime);
        HandleCamPosIfOutOfBounds(ref possibleCamPos);
        transform.position = new Vector3(possibleCamPos.x, possibleCamPos.y, -10);
    }
    private void FollowMouse()
    {
        Vector2 possibleCamPos = Vector2.Lerp(transform.position, MultiplatformInput.GetInputPos(), followSpeed * Time.deltaTime);
        HandleCamPosIfOutOfBounds(ref possibleCamPos);
        transform.position = new Vector3(possibleCamPos.x, possibleCamPos.y, -10);
    }




    private void HandleCamPosIfOutOfBounds(ref Vector2 _targetPos)
    {
        if (camPlacement == E_CAM_PLACEMENT.WORLD)
        {
            Vector2 halfSize = LevelManager.ref_lvlManager.levelBounds.size / 2;
            Vector2 center = LevelManager.ref_lvlManager.levelBounds.bounds.center;
            Vector2 camPos = _targetPos;
            Vector2 halfCamSize = new Vector2((Screen.width * Camera.main.orthographicSize * 2) / Screen.height / 2, Camera.main.orthographicSize);

            if (camPos.x - halfCamSize.x < center.x - halfSize.x)
                _targetPos.x = center.x - halfSize.x + halfCamSize.x;
            if (camPos.x + halfCamSize.x > center.x + halfSize.x)
            {
                _targetPos.x = center.x + halfSize.x - halfCamSize.x;
                Debug.Log(_targetPos.x + " = " + (center.x + halfSize.x - halfCamSize.x));
            }
            if (camPos.y + halfCamSize.y > center.y + halfSize.y)
                _targetPos.y = center.y + halfSize.y - halfCamSize.y;
            if (camPos.y - halfCamSize.y < center.y - halfSize.y)
                _targetPos.y = center.y - halfSize.y + halfCamSize.y;
        }        
    }



    public void SetCamPlacement(E_CAM_PLACEMENT _camPlacement)
    {
        camPlacement = _camPlacement;        
    }


}
