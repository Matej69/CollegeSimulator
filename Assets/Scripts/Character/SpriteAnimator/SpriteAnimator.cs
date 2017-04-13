using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterStats))]
public class SpriteAnimator : MonoBehaviour {
    
    private Dictionary<CharacterInfo.E_CHAR_ACTION, Sprite[]> allAnimations = new Dictionary<CharacterInfo.E_CHAR_ACTION, Sprite[]>();
    private int curFrame = 0;
        
    private CharacterStats playerState;
    private SpriteRenderer renderer;

    Timer nextFrameTimer;

    void Awake()
    {
        playerState = GetComponent<CharacterStats>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start ()
    {
        InitAnimations(playerState.charType);
        nextFrameTimer = new Timer(0.05f);        
    }
	
	// Update is called once per frame
	void Update ()
    {
        RunAnimation(playerState.actionState);
    }





    private void InitAnimations(CharacterInfo.E_CHAR _charID)
    {
        for (int i = 0; i < (int)CharacterInfo.E_CHAR_ACTION.SIZE; ++i)
            allAnimations[(CharacterInfo.E_CHAR_ACTION)i] = GraphicsResources.GetCharSprites(_charID, (CharacterInfo.E_CHAR_ACTION)i);
    }

    private void SetAnimationSpeed(float _frameSpeed)
    {
        nextFrameTimer.startTime = _frameSpeed;
    }

    private void RunAnimation(CharacterInfo.E_CHAR_ACTION _animID)
    {
        if (nextFrameTimer.IsFinished())
        {
            renderer.sprite = allAnimations[_animID][curFrame];
            curFrame = (++curFrame) % allAnimations[_animID].Length;
            SetAnimationSpeed(CharacterInfo.GetAnimationSpeed(playerState.actionState));
            nextFrameTimer.Reset();
        }
        else
        {
            nextFrameTimer.Tick(Time.deltaTime);
        }
    }
    

}
