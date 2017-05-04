using UnityEngine;
using System.Collections;

public class FreeAudioObject : MonoBehaviour {



    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
            Destroy(gameObject);
    }
	
}
