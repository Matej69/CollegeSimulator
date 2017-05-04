using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    //AUDIO INFO
    public enum E_VOLUME_STATE
    {
        MUTED,
        NOT_MUTED
    }
    public E_VOLUME_STATE volumeState = E_VOLUME_STATE.NOT_MUTED;
    
        
    public enum E_AUDIO_ID
    {
        BACKGROUND1,
        BACKGROUND2,
        BACKGROUND3,
        SAD_ENDING,
        DOOR,
        UPGRADE
    }
    [System.Serializable]
    public class AudioInfo
    {
        public E_AUDIO_ID id;
        public AudioClip clip;
    }
        
    public List<AudioInfo> audioInfos;
    private AudioInfo GetAudioInfo(E_AUDIO_ID _id)
    {
        foreach (AudioInfo info in audioInfos)
            if (info.id == _id)
                return info;
        Debug.LogError("audio info with ID = " + _id + " COULD NOT BE LOADED");
        return null;
    }

    //REFRENCES
    private AudioSource backgroundSource;
    //PREFAB
    public GameObject pref_freeAudio;

    
    void Update()
    {
        HadleBackgroundMusicChange();
    }

	void Awake()
    {
        backgroundSource = GetComponent<AudioSource>();
        AudioManager.instance = this;
    }


    public void SetBackgroundMusic(E_AUDIO_ID _id)
    {
        backgroundSource.Stop();
        backgroundSource.clip = GetAudioInfo(_id).clip;
        backgroundSource.Play();
    }
    
    public void CreateSoundObject(E_AUDIO_ID _id)
    {
        GameObject newSound = Instantiate(pref_freeAudio);
        newSound.GetComponent<AudioSource>().clip = GetAudioInfo(_id).clip;
        newSound.GetComponent<AudioSource>().volume = (volumeState == E_VOLUME_STATE.MUTED) ? 0f : ( (_id == E_AUDIO_ID.DOOR) ? 1f : 0.275f);
        newSound.GetComponent<AudioSource>().Play();
    }

    //HANDLE BACKGROUND MUSIC CHANGE
    private void HadleBackgroundMusicChange()
    {
        //set proper volume
        backgroundSource.volume = (volumeState == E_VOLUME_STATE.MUTED) ? 0f : 0.25f;
        //switch to new song when current finished
        if (!backgroundSource.isPlaying)
        {
            E_AUDIO_ID randID = (E_AUDIO_ID)(Random.Range(0, 3));
            SetBackgroundMusic(randID);
        }                
    }

    



}
