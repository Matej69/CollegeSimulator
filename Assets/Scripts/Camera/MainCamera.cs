using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    static public MainCamera ref_cam;
    
    private float followSpeed = 1.7f;


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
            FollowPlayer();
        else
            FollowMouse();
	}




    
    private void FollowPlayer()
    {
        Vector2 camPos = Vector2.Lerp(transform.position, LevelManager.ref_lvlManager.controlledCharacter.transform.position, followSpeed * Time.deltaTime);
        transform.position = new Vector3(camPos.x, camPos.y, -10);
    }
    private void FollowMouse()
    {
        Vector2 camPos = Vector2.Lerp(transform.position, MultiplatformInput.GetInputPos(), followSpeed * Time.deltaTime);
        transform.position = new Vector3(camPos.x, camPos.y, -10);
    }


}
