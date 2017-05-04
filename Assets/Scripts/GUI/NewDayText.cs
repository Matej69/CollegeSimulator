using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewDayText : MonoBehaviour {

    public static NewDayText instance;

    private float reduceOpacitySpeed = 0.65f;

    public Text frontText;
    public Text borderText;

    // Use this for initialization
    void Start ()
    {
        instance = this;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ReduceColorOpacity();
        if (Input.GetKeyDown(KeyCode.A))
            EnableText("day 2");
    }



    public void EnableText(string _text)
    {
        frontText.text = _text;
        borderText.text = _text;
        Color colFront = frontText.GetComponent<Text>().color;
        Color colBorder = borderText.GetComponent<Text>().color;
        colFront.a = colBorder.a = 1;
        frontText.GetComponent<Text>().color = colFront;
        borderText.GetComponent<Text>().color = colBorder;
    }

    private void ReduceColorOpacity()
    {
        if (frontText.color.a <= 0)
            return;

        Color colFront = frontText.GetComponent<Text>().color;
        Color colBorder = borderText.GetComponent<Text>().color;
        colFront.a = colBorder.a -= reduceOpacitySpeed * Time.deltaTime;
        frontText.GetComponent<Text>().color = colFront;
        borderText.GetComponent<Text>().color = colBorder;
    }
    

}
