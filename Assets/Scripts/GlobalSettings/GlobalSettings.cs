using UnityEngine;
using System.Collections;

public class GlobalSettings : MonoBehaviour {

    public bool isFramerateLocked = false;
    public int lockTo = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isFramerateLocked)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = lockTo;
        }
	
	}
}
