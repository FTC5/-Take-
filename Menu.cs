using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//SampleScene
public class Menu : MonoBehaviour {
    public void OnClassicMod()
    {
        Generator.stateOfLoad = 0;
        SceneManager.LoadScene("GameMod");
    }
    public void OnRandomMod()
    {
        Generator.stateOfLoad = 1;
        SceneManager.LoadScene("GameMod");
    }
    public void OnLoadMod()
    {
        Generator.stateOfLoad = 2;
        SceneManager.LoadScene("GameMod");
    }
    public void HelpMod()
    {    
        GameObject.Find("Canvas").GetComponent<Message>().View_Message();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
