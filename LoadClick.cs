using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class LoadClick : MonoBehaviour {
    private void OnMouseDown()
    {
        GameObject.Find("Main Camera").GetComponent<Generator>().LoadLastGame(LoadGame());
        transform.localScale = new Vector3(transform.localScale.x / 2f, transform.localScale.y / 2f, transform.localScale.z / 2f);
    }
    private void OnMouseUp()
    {
         transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f);
    }
    public string[] LoadGame()
    {
        int lenght=0;
        Time.timeScale = 0;
        string[] names;
        try
        {
            using (BinaryReader reader = new BinaryReader(File.Open("save.bin", FileMode.Open)))
            {
                    if (reader.PeekChar() > -1)
                    {
                        Generator.stateOfLoad = reader.ReadInt32();
                        lenght = reader.ReadInt32();
                        GameObject.Find("Main Camera").GetComponent<Generator>().SetScore(reader.ReadInt32());
                        GameObject.Find("SaveGameButton").GetComponent<LapTimeManager>().SetTime(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
                    }
                    names = new string[lenght];
                    for (int i=0;i< lenght;i++)
                    {
                        if (reader.PeekChar() > -1)
                        {
                            names[i] = reader.ReadString();
                        }
                     }
                Time.timeScale = 1;
                
            }
            return names;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex, this);
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }
        Time.timeScale = 1;
        return null;
    }
}
