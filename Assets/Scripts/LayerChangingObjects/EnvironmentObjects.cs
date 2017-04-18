using UnityEngine;
using System.Collections;

public class EnvironmentObjects : MonoBehaviour, IVertAxisLayering
{
    
	
	// Update is called once per frame
	void Update ()
    {
        SetProperLayer();

    }


    public void SetProperLayer()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }


}
