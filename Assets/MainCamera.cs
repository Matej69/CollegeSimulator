using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    static public MainCamera ref_cam;

    private GameObject charToFolow = null;
    private float followSpeed = 1.3f;


    void Awake()
    {
        ref_cam = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (charToFolow)
            FollowPlayer();
	
	}

    public void SetCharToFollow(GameObject _char)
    {
        charToFolow = _char;
    }
    private void FollowPlayer()
    {
        Vector2 camPos = Vector2.Lerp(transform.position, charToFolow.transform.position, followSpeed * Time.deltaTime);
        transform.position = new Vector3(camPos.x, camPos.y, -10);
    }


}
