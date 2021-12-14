using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitClick : MonoBehaviour {

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(transform.localScale.x / 2f, transform.localScale.y / 2f, transform.localScale.z / 2f);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f);
        Message.mes="Score : "+ GameObject.Find("Main Camera").GetComponent<Generator>().GetScore()+ "\nTime : " 
            + GameObject.Find("SaveGameButton").GetComponent<LapTimeManager>().GetTime();
        Message.Index = -1;
        SceneManager.LoadScene("MainMenu");
    }
}
