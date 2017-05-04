using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour {
    
    public Sprite spr_muted, spr_notMuted;

    void Start()
    {
        SetClickListener();
    }
    void SetClickListener()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            if(AudioManager.instance.volumeState == AudioManager.E_VOLUME_STATE.NOT_MUTED)
            {
                AudioManager.instance.volumeState = AudioManager.E_VOLUME_STATE.MUTED;
                GetComponent<Image>().sprite = spr_muted;
            }            
            else if (AudioManager.instance.volumeState == AudioManager.E_VOLUME_STATE.MUTED)
            {
                AudioManager.instance.volumeState = AudioManager.E_VOLUME_STATE.NOT_MUTED;
                GetComponent<Image>().sprite = spr_notMuted;
            }            
        });
    }
    
    
	
}
