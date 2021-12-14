using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {
    private static int index = 0;
    public static string mes = "";
    public Image myImage;
    public GameObject imageB;
    public Text txt;
    public Sprite []mySprite=new Sprite[5];
    public static int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = value;
        }
    }

    // Use this for initialization
    void Start () {
        imageB.SetActive(false);
        myImage.enabled = false;
        txt.enabled = false;
    }
                
	// Update is called once per frame
	void Update () {
		if(Index==-1)
        {
            View_Message();
        }
	}
    public void View_Message()
    {
        switch(Index){
            case 0:
                imageB.SetActive(true);
                myImage.enabled = true;
                myImage.sprite = mySprite[index];
                index = 1;
                break;
            case 1:
            case 2:
            case 3:
                myImage.sprite = mySprite[index];
                index += 1;
                break;
            case 4:
                myImage.sprite = mySprite[index];
                index += 1;
                imageB.GetComponentInChildren<Text>().text = "Close";
                break;
            case 5:
                imageB.SetActive(false);
                myImage.enabled = false;
                index = 0;
                imageB.GetComponentInChildren<Text>().text = "Next";
                break;
            case -1:
                myImage.sprite = null;
                imageB.SetActive(true);
                myImage.enabled = true;
                txt.enabled = true;
                txt.text = mes;
                Index = -2;
                imageB.GetComponentInChildren<Text>().text = "Close";
                break;
            case -2:
                imageB.SetActive(false);
                myImage.enabled = false;
                txt.enabled = false;
                Index = 0;
                imageB.GetComponentInChildren<Text>().text = "Next";
                break;
        }
    }
}
