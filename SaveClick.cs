using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class SaveClick : MonoBehaviour {
    private void OnMouseDown()
    {
        SaveGame(GameObject.Find("Main Camera").GetComponent<Generator>().GetObjects());
        transform.localScale = new Vector3(transform.localScale.x / 2f, transform.localScale.y / 2f, transform.localScale.z / 2f);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f);
        SceneManager.LoadScene("MainMenu");
    }
    private void SaveGame(GameObject[] objs)
    {
        Time.timeScale = 0;
        try
        {
            // создаем объект BinaryWriter
            using (BinaryWriter writer = new BinaryWriter(File.Open("save.bin", FileMode.OpenOrCreate)))
            {
                // записываем в файл значение каждого поля структуры
                writer.Write(Generator.GetstateOfLoad());
                writer.Write(GameObject.Find("Main Camera").GetComponent<Generator>().Getlenght());
                writer.Write(GameObject.Find("Main Camera").GetComponent<Generator>().GetScore());
                writer.Write(GetComponent<LapTimeManager>().SecCount1);
                writer.Write(GetComponent<LapTimeManager>().MinuteCount1);
                writer.Write(GetComponent<LapTimeManager>().Hour1);
                foreach (GameObject objet in objs)
                {
                    if (objet == null)
                    {
                        writer.Write((-1).ToString());
                    }
                    else
                    {
                        writer.Write((string)objet.name);
                    }
                        
                }
            }
        }catch(Exception ex)
        {
            Debug.LogException(ex, this);
        }
        Time.timeScale = 1;
    }
}
