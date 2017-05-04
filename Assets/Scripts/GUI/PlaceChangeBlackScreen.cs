using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaceChangeBlackScreen : MonoBehaviour {

    private static PlaceChangeBlackScreen instance;
    
    
    private Image comp_img;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        comp_img = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        ReduceOpacity(1f);        	
	}

    void ReduceOpacity(float _speed)
    {
        Color col = comp_img.color;
        col.a -= _speed * Time.deltaTime;
        comp_img.color = col;
    }


    public static void TriggerBlackScreen()
    {
        Color resCol = instance.comp_img.color;
        resCol.a = 1;
        instance.comp_img.color = resCol; 
    }


}
